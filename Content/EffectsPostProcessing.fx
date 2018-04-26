Texture Texture;

float Brightness;
float Gamma;
float Contrast;
float Saturation;


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
	AddressU = clamp;
	AddressV = clamp;
};


VertexShaderOutput VertexShader(VertexShaderInput input)
{
    VertexShaderOutput output;
    output.Position = input.Position;
    output.TexCoord = input.TexCoord;
    return output;
}


float4 PixelShader(VertexShaderOutput input) : COLOR0
{
	float4 color = tex2D(TextureSampler, input.TexCoord);
	float3 color3 = (float3)color;
	
	float3 LuminosityCoeffs = float3(0.2125, 0.7154, 0.0721);
	float3 AvgLuminosity = float3(0.5, 0.5, 0.5);
	float InvGamma = 1 / Gamma;

	color3 = color3 * Brightness;
	float3 luminosity = dot(color3, LuminosityCoeffs);
	color3 = lerp(luminosity, color3, Saturation);
	color3 = saturate(lerp(AvgLuminosity, color3, Contrast));
	color3 = pow(color3, InvGamma);

	return float4(color3, color.a);
}


float4 PixelShaderNone(VertexShaderOutput input) : COLOR0
{
	return tex2D(TextureSampler, input.TexCoord);
}


technique PostProcessing
{
    pass Pass1
    {
        VertexShader = compile vs_1_1 VertexShader();
        PixelShader = compile ps_2_0 PixelShader();
    }
}


technique PostProcessingNone
{
    pass Pass1
    {
        VertexShader = compile vs_1_1 VertexShader();
        PixelShader = compile ps_1_1 PixelShaderNone();
    }
}
