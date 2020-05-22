Shader "Unlit/GreyToColorUnlit"
{
	Properties
	{
		_ForegroundColor("Foreground Color", Color) = (0,0,0,1)
		_BackgroundColor("Background Color", Color) = (1,1,1,1)
		_UseTransparentBackground("Use Transparent Background", Float) = 0
        _MainTex("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
		Blend SrcAlpha One
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
			
            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

			float4 _ForegroundColor;
			float4 _BackgroundColor;
			bool _UseTransparentBackground;
            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 grey = tex2D(_MainTex, i.uv);
				fixed grad = (grey.r + grey.g + grey.b) / 3;

				// lerp color
				fixed4 col = lerp(_ForegroundColor, _BackgroundColor, grad);
				if (_UseTransparentBackground == 1 && grad == 1)
				{
					col.a = 0;
				}

                return col;
            }
            ENDCG
        }
    }
}
