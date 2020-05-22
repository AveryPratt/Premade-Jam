Shader "Custom/GreyToColorStandard"
{
    Properties
    {
		_ForegroundColor("Foreground Color", Color) = (0,0,0,1)
		_BackgroundColor("Background Color", Color) = (1,1,1,1)
		_UseTransparentBackground("Use Transparent Background", Float) = 0

        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }
		Blend SrcAlpha One
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

		float4 _ForegroundColor;
		float4 _BackgroundColor;
		bool _UseTransparentBackground;

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
			fixed4 grey = tex2D(_MainTex, IN.uv_MainTex);
			fixed grad = (grey.r + grey.g + grey.b) / 3;

			// lerp color
			fixed4 c = lerp(_ForegroundColor, _BackgroundColor, grad);
			if (_UseTransparentBackground == 1 && grad == 1)
			{
				c.a = 0;
			}

            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
