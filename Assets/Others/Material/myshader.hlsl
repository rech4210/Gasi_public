
#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
struct Attribute
{
    float3 positionOS: POSITION;
    float2 uv : TEXCOORD0;
};

struct Varyings
{
    float4 posCS: SV_POSITION; // 클립 스페이스의 버텍스 위치를 포함하고 있다는 Syntax
    float2 uv : TEXCOORD0;
};

float4 _BaseColor;
TEXTURE2D(_MainTex); // TEXTURE2D 함수는 
SAMPLER(sampler_MainTex); // 텍스쳐를 불러올지에 대한 매크로 왼쪽은 샘플러 오른쪽을 텍스쳐
float4 _MainTex_ST; // ST 타입에 유니티가 자동적으로 값을 저장해줌

#define MACRO(argument) argument + 2 // 매크로

Varyings vert(Attribute input)
{
    Varyings output;
    VertexPositionInputs posinput = GetVertexPositionInputs(input.positionOS)
    ;
    // GetVertexPositionInputs 는 버텍스의 매트릭스 연산을 하는 부분임.
    output.posCS = posinput.positionCS;
    output.uv = TRANSFORM_TEX(input.uv, _MainTex); // 해당 함수 부분에서 UV를 바꿔줌
    return output;
}

//#define TRANSFORM_TEX(tex, name) (tex.xy * name##_ST.xy,name##_ST.zw)
// TRANSFORM_TEX에서 메인 텍스트를 _ST로 바꿔 연산을 수행해줌

float4 frag(Varyings i) : SV_TARGET // 최종 픽셀값을 포함하는 함수라는 의미
{
    float4 colorSample = SAMPLE_TEXTURE2D(_MainTex,sampler_MainTex,i.uv);
    

    InputData lightingInput = (InputData)0;
    SurfaceData surfaceInput = (SurfaceData)0;

    return UniversalFragmentBlinnPhong(lightingInput,surfaceInput);
}
