Shader "Unlit/Cartoon"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        [HDR] _AmbientColor ("_AmbientColor", AmbientColor) = (0.4,0.4,0.4)
    }
    SubShader
    {
        Tags 
        { 
            "RenderType" = "Opaque" 
            "LightMode" = "ForwardBase"
            "PassFlags" = "OnlyDirectional"
        }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
#include "Lighting."

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

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _Color;
            float4 _AmbientColor;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                // Phong Shading
                float3 normal = normalize(i.worldNormal);
                float NdotL = dot(normal, _WorldSpaceLightPos0);

                // Two Tone
                float lightIntensity = smoothstep(0, 0.01, NdotL);
                float4 lightColor = _LightColor0 * lightIntensity;
                return col * _Color * (_AmbientColor + lightColor);
            }
            ENDCG
        }
    }
}
