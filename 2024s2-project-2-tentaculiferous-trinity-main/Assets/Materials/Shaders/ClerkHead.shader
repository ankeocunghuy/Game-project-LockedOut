// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/ClerkHead"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Tiling ("Tiling", Vector) = (1, 1, 0, 0) // If tiling is desired
        _ScrollSpeed ("Texture Scroll Speed", Vector) = (0.0,0.1,0.0,0.0) // Scroll speed in x and y directions
        _GlowColor ("Glow Color", Color) = (0, 1, 0, 1) // Color of glow
        _GlowIntensity ("Glow Intensity", Float) = 1.0 // Intensity of glow
        // Variables for phong shader
        _Ka("Ka", Float) = 1.0
		_Kd("Kd", Float) = 1.0
		_Ks("Ks", Float) = 1.0
		_fAtt("fAtt", Float) = 1.0
		_specN("specN", Float) = 1.0
        _PointLightColor("Point Light Color", Color) = (0, 0, 0)
		_PointLightPosition("Point Light Position", Vector) = (0.0, 0.0, 0.0)
	}
    SubShader
    {
        // No culling or depth
        Tags { "RenderType"="Opaque" }

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
                float4 normal : NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float4 worldVertex : TEXCOORD1;
                float3 worldNormal : TEXCOORD2;
            };

            float4 _Tiling;
            float4 _ScrollSpeed;
            float4 _GlowColor;
            float _GlowIntensity;
            uniform float3 _PointLightColor;
			uniform float3 _PointLightPosition;
			uniform float _Ka;
			uniform float _Kd;
			uniform float _Ks;
			uniform float _fAtt;
			uniform float _specN;

            // From ChatGPT
            // Simple pseudo-random function using UVs
            float random(float input)
            {
                // return frac(input * 1.37346321) * 0.4;
                // Use a hashing technique to generate a pseudo-random number
                return frac(sin(input + 13) * 46758.5453) * -0.15;
            }

            v2f vert (appdata v)
            {
                v2f o;

                // Pass vertexes through in relation to camera
                o.vertex = UnityObjectToClipPos(v.vertex);//UnityObjectToClipPos(v.vertex);

                // Calculate and store world vertex and world normal
                o.worldVertex = mul(unity_ObjectToWorld, v.vertex);
                o.worldNormal = normalize(mul(transpose((float3x3)unity_WorldToObject), v.normal.xyz));

                // Calculate tiling and scroll
                float2 offset = float2(0.0f, 0.0f);
                int curChunk = floor(v.uv.x * _Tiling.x);
                offset = float2(_ScrollSpeed.x, _ScrollSpeed.y) * _Time.y;
                o.uv = v.uv * _Tiling.xy + offset;

                return o;
            }

            sampler2D _MainTex;

            float4 frag (v2f i) : SV_Target
            {
                // Texture color before alterations
                float4 texColor = tex2D(_MainTex, i.uv);

                // Normalize world normal
                float3 interpNormal = normalize(i.worldNormal);

                // Ambient RGB intensities
				float Ka = _Ka;
				float3 amb = texColor.rgb * UNITY_LIGHTMODEL_AMBIENT.rgb * Ka;

                // Diffuse RBG reflections
				float fAtt = _fAtt;
				float Kd = _Kd;
				float3 L = normalize(_PointLightPosition - i.worldVertex.xyz);
				float LdotN = dot(L, interpNormal);
				float3 dif = fAtt * _PointLightColor.rgb * Kd * texColor.rgb * saturate(LdotN);

                // Specular reflections
				float Ks = _Ks;
				float specN = _specN;
				float3 V = normalize(_WorldSpaceCameraPos - i.worldVertex.xyz);
                specN = _specN;
				float3 H = normalize(V + L);
				float3 spe = fAtt * _PointLightColor.rgb * Ks * pow(saturate(dot(interpNormal, H)), specN);

                // Combine
				float4 phongColor = float4(0.0f, 0.0f, 0.0f, 0.0f);
				phongColor.rgb = amb.rgb + dif.rgb + spe.rgb;
				phongColor.a = texColor.a;

                return phongColor + _GlowColor * _GlowIntensity;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
