Shader "Custom/TwoSidedMaterial"
{
    Properties
    {
        _FrontTex ("Front Texture", 2D) = "white" {}
        _BackTex ("Back Texture", 2D) = "white" {}
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Cull off // Cull the front faces (only render back faces for the back texture)

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            sampler2D _FrontTex;
            sampler2D _BackTex;

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 pos : SV_POSITION;
                float3 normal : TEXCOORD1;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.normal = mul((float3x3)unity_ObjectToWorld, v.normal);
                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                // Check if the normal is facing the camera
                float facing = dot(i.normal, float3(0, 0, 1));
                
                // Use front texture if facing towards the camera, back texture otherwise
                half4 color = (facing > 0) ? tex2D(_FrontTex, i.uv) : tex2D(_BackTex, i.uv);
                return color;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
