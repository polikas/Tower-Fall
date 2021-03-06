﻿Shader "myShader/clickShader"
{
    Properties
    {
        _MainTex ("Main Texture", 2D) = "white" {}
		_RimColor ("Rim Color", Color) = (0.23,0.19,0.16,0.0)
		_RimPower("Rim Power", Range(0.5,8.0)) = 3.0
    }
    SubShader
    {
     
        CGPROGRAM
      
        #pragma surface surf Lambert

       

        sampler2D _MainTex;
		float4 _RimColor;
		float _RimPower;

        struct Input
        {
            float2 uv_MainTex;
			float3 viewDir;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
			half rim = 1.0 - saturate(dot(normalize(IN.viewDir), o.Normal));
			o.Emission = _RimColor.rgb * pow(rim, _RimPower);
        }
        ENDCG
    }
    FallBack "Diffuse"
}
