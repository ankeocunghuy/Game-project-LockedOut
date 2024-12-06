Shader "Unlit/LavaRipples"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _HeightMap ("Height Map", 2D) = "white" {}
        _Height ("Height", Float) = 0.15
        _FlowSpeed ("Flow Speed", Vector) = (0.2, 0.2, 0.0, 0.0)
        _RippleSpeed ("Ripple Speed", Vector) = (0.4, 0.6, 0.0, 0.0)
        _GlowColor ("Glow Color", Color) = (1, 1, 1, 1)
        _GlowStrength ("Glow Strength", Float) = .3
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
// Upgrade NOTE: excluded shader from DX11; has structs without semantics (struct appdata members heightMap)
#pragma exclude_renderers d3d11
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

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

            sampler2D _MainTex;
            float4 _MainTex_ST;
            sampler2D _HeightMap;
            float _Height;
            float4 _FlowSpeed;
            float4 _RippleSpeed;
            float4 _GlowColor;
            float _GlowStrength;

            v2f vert (appdata v)
            {
                v2f o;
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                float2 rippleFlow = float2(_RippleSpeed.x, _RippleSpeed.y) * _Time.y;
                float height = tex2Dlod(_HeightMap, float4(v.uv.x + rippleFlow.x, v.uv.y + rippleFlow.y, 0, 0)).b;
                float3 changedVert = v.vertex;
                changedVert.z += height * _Height - _Height;
                o.vertex = UnityObjectToClipPos(changedVert);
                float2 lavaFlow = float2(_FlowSpeed.x, _FlowSpeed.y) * _Time.y;
                o.uv += lavaFlow;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                col += _GlowColor * _GlowStrength;
                return col;
            }
            ENDCG
        }
    }
}
