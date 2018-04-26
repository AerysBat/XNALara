float4x4 World;
float4x4 View;
float4x4 Projection;

float3 CameraPosition;

Texture Texture;
float4 Color;

float3 BillboardPosition;
float BillboardWidth;
float BillboardHeight;

bool AlphaOnly;


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
	magfilter = LINEAR; 
	minfilter = LINEAR; 
	mipfilter = LINEAR; 
	AddressU = wrap;
	AddressV = wrap;
};


VertexShaderOutput SphericalVS(VertexShaderInput input)
{
    VertexShaderOutput output;
    float3 position = (float3)mul(float4(BillboardPosition, 1), World);
    float3 eyeVector = position - CameraPosition;
    float3 sideVector = normalize(cross(eyeVector, float3(0, 1, 0)));
    float3 upVector = normalize(cross(sideVector, eyeVector));
    position += (input.TexCoord.x - 0.5) * sideVector * BillboardWidth;
    position += (0.5 - input.TexCoord.y) * upVector * BillboardHeight;
    float4x4 ViewProjection = mul(View, Projection);
    output.Position = mul(float4(position, 1), ViewProjection);
    output.TexCoord = input.TexCoord;
    return output;
}


float4 PixelShaderFunction(VertexShaderOutput input) : COLOR0
{
	float4 diffuse = tex2D(TextureSampler, input.TexCoord);
	if (!AlphaOnly) {
		diffuse *= Color;
	}
	return diffuse;
}


technique SphericalBillboard
{
    pass Pass1
    {
        VertexShader = compile vs_1_1 SphericalVS();
        PixelShader = compile ps_1_1 PixelShaderFunction();
    }
}
