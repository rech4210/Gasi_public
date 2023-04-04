Shader "Unlit/KMSlight"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags {"RenderPipeline" ="UniversalPipeline"  "RenderType" = "Opaque"}
        Pass
        {
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #pragma vertex vert
            #pragma fragment frag


            HLSLPROGRAM

            ENDHLSL
            
        }
    }
}
