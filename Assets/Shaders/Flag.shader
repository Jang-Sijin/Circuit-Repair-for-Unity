Shader "Custom/Flag"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Noise("Noise", 2D) = "white" {}
        _NoiseScaleX("Noise Scale X", Float) = 10
        _NoiseScaleY("Noise Scale Y", Float) = 20
        _TimeScaleX("Time Scale X", Float) = 1
        _TimeScaleY("Time Scale Y", Float) = 0.5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }        

        CGPROGRAM        
        #pragma surface surf Lambert vertex:vert        
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _Noise;
        fixed4 _Color;
        float _NoiseScaleX;
        float _NoiseScaleY;
        float _TimeScaleX;
        float _TimeScaleY;

        struct Input
        {
            float2 uv_MainTex;
        };       

        void vert(inout appdata_base v, out Input o)
        {
            UNITY_INITIALIZE_OUTPUT(Input, o);

            float2 uv = v.texcoord;
            uv += float2(1 / _NoiseScaleX, 1 / _NoiseScaleY);
            uv += float2(_Time.x * _TimeScaleX, _Time.x * _TimeScaleY);

            float noise = tex2Dlod(_Noise, float4(uv, 0, 0)).r;
            float offset = noise * 2 - 1;

            offset += v.texcoord.x;
            v.vertex.y += offset;
            v.vertex.x += offset;
            v.vertex.z += offset;
        }

        void surf (Input IN, inout SurfaceOutput o)
        {            
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
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
