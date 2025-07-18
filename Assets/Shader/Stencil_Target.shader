Shader "Unlit/Stencil_Target"
{
    Properties
    {
        _Color("Base Color", Color) = (1, 1, 1, 1) // 기본 색상
        _MainTex("Base (RGB)", 2D) = "white" {}   // 텍스처
    }

    SubShader
    {
        Tags
        {
            "RenderType" = "Opaque"
            "Queue" = "Transparent"
        }

        Pass
        {
            Stencil
            {
                Ref 1
                Comp Equal
                Pass Replace
            }
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _Color;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };

            struct v2f
            {
                float4 position : SV_POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.position = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.color = v.color;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 texColor = tex2D(_MainTex, i.uv) * _Color * i.color;

                if (texColor.a < 0.5) discard;

                return texColor;
            }

            ENDCG
        }
    }
}
