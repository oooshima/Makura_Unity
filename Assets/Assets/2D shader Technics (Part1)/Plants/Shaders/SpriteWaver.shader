// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'


Shader "Custom/SpriteWaver"
{
	Properties
	{
		_Color("Tint", Color) = (1,1,1,1)
		_MainTex("Sprite Texture", 2D) = "white" {}
		[MaterialToggle] PixelSnap("Pixel snap", Float) = 0

		_VelocityX("X speed",Range(0,5.0)) = 1
		_AmplitudoX("X const amplitude",Range(-15,15)) = 1

		_VelocityY("Y speed",Range(0,5.0)) = 1
		_AmplitudoY("Y const amplitude",Range(-15,15)) = 1

		[MaterialToggle] Custom ("Custom Editor", Float) = 1.0
		_Rect("CE rect",Vector) = (0,0,0,0)
	}

	SubShader
	{
			Tags
		{
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent"
			"PreviewType" = "Plane"
			"CanUseSpriteAtlas" = "True"
		}

			Cull Off
			Lighting Off
			ZWrite Off
			Fog{ Mode Off }
			Blend One OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile DUMMY PIXELSNAP_ON
			#include "UnityCG.cginc"

			struct appdata_t
			{
				float4 vertex   : POSITION;
				float4 color    : COLOR;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex   : SV_POSITION;
				fixed4 color : COLOR;
				half2 texcoord  : TEXCOORD0;
			};

			fixed4 _Color;
			float _VelocityX;
			float _VelocityY;
			float Custom;
			float _AmplitudoX;
			float _AmplitudoY;
			float4 _Rect;

			v2f vert(appdata_t IN)
			{
				v2f OUT;

				if (Custom != 0) {
					if (IN.vertex.x < _Rect.x || IN.vertex.x > _Rect.y) {
						_AmplitudoX = 0;
						_AmplitudoY = 0;
					}
					if (IN.vertex.y > _Rect.z || IN.vertex.y < _Rect.w)
					{
						_AmplitudoY = 0;
						_AmplitudoX = 0;
					}
				}

				float4 offset = float4(
					sin(IN.vertex.y / 340 + _Time[1] * _VelocityX) *_AmplitudoX,
					sin(IN.vertex.x / 340 + _Time[1] * _VelocityY) *_AmplitudoY,
					0,
					0
				);

				OUT.vertex = UnityObjectToClipPos(IN.vertex + offset);
				OUT.texcoord = IN.texcoord;
				OUT.color = IN.color * _Color;
			#ifdef PIXELSNAP_ON
				OUT.vertex = UnityPixelSnap(OUT.vertex);
			#endif

				return OUT;
			}

			sampler2D _MainTex;

			fixed4 frag(v2f IN) : SV_Target
			{
				fixed4 c = tex2D(_MainTex, IN.texcoord) * IN.color;
				c.rgb *= c.a;
				return c;
			}
			ENDCG
		}
	}
}