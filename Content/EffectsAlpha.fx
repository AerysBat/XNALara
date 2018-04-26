float4x4 World;
float4x4 View;
float4x4 Projection;

Texture DiffuseTexture;

float4x4 BoneMatrices[59];
float4x4 RootMatrix;


struct VertexShaderBasicInput
{
    float4 Position: POSITION0;
    float2 TexCoord: TEXCOORD0;
};


struct VertexShaderBonesInput
{
    float4 Position: POSITION0;
    float4 Normal: NORMAL0;
    float2 TexCoord: TEXCOORD0;
    float4 Tangent: TANGENT0;
    float4 BoneIndices: BLENDINDICES0;
    float4 BoneWeights: BLENDWEIGHT0;
};


struct VertexShaderOutput
{
    float4 Position: POSITION0;
    float2 TexCoord: TEXCOORD0;
};


sampler DiffuseTextureSampler = sampler_state { 
	texture = <DiffuseTexture>; 
	magfilter = LINEAR; 
	minfilter = LINEAR; 
	mipfilter = LINEAR; 
	AddressU = wrap;
	AddressV = wrap;
};


float4x4 CalcBoneTransform(VertexShaderBonesInput input)
{
	float4x4 boneTransform = 0;
	boneTransform += BoneMatrices[input.BoneIndices[0]] * input.BoneWeights[0];
	boneTransform += BoneMatrices[input.BoneIndices[1]] * input.BoneWeights[1];
	boneTransform += BoneMatrices[input.BoneIndices[2]] * input.BoneWeights[2];
	boneTransform += BoneMatrices[input.BoneIndices[3]] * input.BoneWeights[3];
	return boneTransform;
}


VertexShaderOutput VertexShaderBasic(VertexShaderBasicInput input)
{
    VertexShaderOutput output;
    float4x4 WorldViewProjection = mul(mul(World, View), Projection);
    output.Position = mul(input.Position, WorldViewProjection);
    output.TexCoord = input.TexCoord;
    return output;
}


VertexShaderOutput VertexShaderRootBone(VertexShaderBonesInput input)
{
    VertexShaderOutput output;
    float4x4 WorldViewProjection = mul(mul(World, View), Projection);
    output.Position = mul(mul(input.Position, RootMatrix), WorldViewProjection);
    output.TexCoord = input.TexCoord;
    return output;
}


VertexShaderOutput VertexShaderBones(VertexShaderBonesInput input)
{
    VertexShaderOutput output;
    float4x4 WorldViewProjection = mul(mul(World, View), Projection);
    float4x4 boneTransform = CalcBoneTransform(input);
    output.Position = mul(mul(input.Position, boneTransform), WorldViewProjection);
    output.TexCoord = input.TexCoord;
    return output;
}


float4 PixelShader(VertexShaderOutput input) : COLOR0
{
	float4 color = tex2D(DiffuseTextureSampler, input.TexCoord);
	color.rgb = 1;
	return color;
}


technique AlphaBasic
{
    pass Pass1
    {
        VertexShader = compile vs_1_1 VertexShaderBasic();
        PixelShader = compile ps_1_1 PixelShader();
    }
}


technique AlphaRootBone
{
    pass Pass1
    {
        VertexShader = compile vs_1_1 VertexShaderRootBone();
        PixelShader = compile ps_1_1 PixelShader();
    }
}


technique AlphaBones
{
    pass Pass1
    {
        VertexShader = compile vs_1_1 VertexShaderBones();
        PixelShader = compile ps_1_1 PixelShader();
    }
}
