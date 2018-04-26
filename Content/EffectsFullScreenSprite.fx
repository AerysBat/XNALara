Texture Texture;

float OffsetX;
float OffsetY;
float ScaleX;
float ScaleY;


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


sampler TextureSampler = sampler_state { 
	texture = <Texture>; 
	magfilter = POINT; 
	minfilter = POINT; 
	mipfilter = POINT; 
	AddressU = wrap;
	AddressV = wrap;
};


VertexShaderOutput VertexShaderFunction(VertexShaderInput input)
{
    VertexShaderOutput output;
    float4 Offset = float4(OffsetX, OffsetY, 0, 0);
    float4 Scale = float4(ScaleX, ScaleY, 1, 1);
    output.Position = Offset + input.Position * Scale;
    output.TexCoord = input.TexCoord;
    return output;
}


float4 PixelShaderFunction(VertexShaderOutput input) : COLOR0
{
	return tex2D(TextureSampler, input.TexCoord);
}


technique FullScreenSprite
{
    pass Pass1
    {
        VertexShader = compile vs_1_1 VertexShaderFunction();
        PixelShader = compile ps_1_1 PixelShaderFunction();
    }
}
