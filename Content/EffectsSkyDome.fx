float4x4 World;
float4x4 View;
float4x4 Projection;

Texture DiffuseTexture;
bool DisplayTextures;


sampler DiffuseTextureSampler = sampler_state { 
	texture = <DiffuseTexture>; 
	magfilter = LINEAR; 
	minfilter = LINEAR; 
	mipfilter = LINEAR; 
	AddressU = wrap;
	AddressV = wrap;
};


struct VertexShaderInput
{
    float4 Position: POSITION0;
    float2 TexCoord: TEXCOORD0;
};


struct VertexShaderOutput
{
    float4 Position: POSITION0;
    float2 TexCoord: TEXCOORD0;
};


float4 GetDiffuseColor(float2 texCoord)
{
	float4 color = tex2D(DiffuseTextureSampler, texCoord);
	if (!DisplayTextures) {
		color.rgb = 1.0;
	}
	return color;
}


VertexShaderOutput GenericVS(VertexShaderInput input)
{
    VertexShaderOutput output;
    float4x4 WorldViewProjection = mul(mul(World, View), Projection);
    output.Position = mul(input.Position, WorldViewProjection);
    output.TexCoord = input.TexCoord;
    return output;
}


float4 SkyDomePS(VertexShaderOutput input) : COLOR0
{
	return GetDiffuseColor(input.TexCoord);
}


technique Dome
{
    pass Pass1
    {
        VertexShader = compile vs_1_1 GenericVS();
        PixelShader = compile ps_1_1 SkyDomePS();
    }
}
