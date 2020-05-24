Shader "Unlit/GreyToColorTransparent"
{
	Properties
	{
		_ForegroundColor("Foreground Color", Color) = (0,0,0,1)
		_BackgroundColor("Background Color", Color) = (1,1,1,1)
		_TransparentClippingLimit("TransparentClippingLimit", Float) = 0.9
		_LightCount("LightCount", Int) = 0
        _MainTex("Texture", 2D) = "white" {}
    }
    SubShader
    {
		Tags { "Queue" = "Transparent" "RenderType" = "Transparent" "IgnoreProjector" = "True" }
		Blend SrcAlpha One
		ZWrite Off
		Cull Off
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
				float4 world_position : WORLD_POSITION;
                float4 vertex : SV_POSITION;
            };

			float4 _ForegroundColor;
			float4 _BackgroundColor;
			float _TransparentClippingLimit;
			float4 _Lights[100];
			int _LightCount;
            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
				o.world_position = mul(unity_ObjectToWorld, v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

			float4 frag (v2f i) : SV_Target
            {

                // sample the texture
				float4 grey = tex2D(_MainTex, i.uv);
				float grad = (grey.r + grey.g + grey.b) / 3;

				// lerp color
				float4 col = lerp(_ForegroundColor, _BackgroundColor, grad);

				bool vis = false;

				for (int j = 0; j < _LightCount; j++)
				{
					float d = distance(i.world_position, _Lights[j]);

					if (d < 4)
					{
						vis = true;
						break;
					}
				}
				if (grad >= _TransparentClippingLimit || !vis)
				{
					col.a = 0;
				}
				col.a *= .5;

                return col;
            }
            ENDCG
        }
    }
}
