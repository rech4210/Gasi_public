Shader "Custom/KMSshader"
{
    Properties
    {
        [MainTexture] _MainTex ("map here", 2D) = "white" {}
        [MainColor]_BaseColor ("Here",Color) =(1,1,1,1)
    }

    SubShader
    {
        Tags {"RenderPipeline"="UniversalPipeline" "RenderType" ="Opaque"}
        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            #include "myshader.hlsl"
            ENDHLSL
        }
    }
}
