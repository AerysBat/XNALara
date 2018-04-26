float4x4 World;
float4x4 View;
float4x4 Projection;

float3 Light1Dir;
float4 Light1Color;
float Light1ShadowDepth;

float3 Light2Dir;
float4 Light2Color;
float Light2ShadowDepth;

float3 Light3Dir;
float4 Light3Color;
float Light3ShadowDepth;

Texture DiffuseTexture;
Texture LightmapTexture;

bool DisplayTextures;
bool EnableLightMaps;

float4x4 RootMatrix;


sampler DiffuseTextureSampler = sampler_state { 
	texture = <DiffuseTexture>; 
	magfilter = LINEAR; 
	minfilter = LINEAR; 
	mipfilter = LINEAR; 
	AddressU = wrap;
	AddressV = wrap;
};


sampler LightmapTextureSampler = sampler_state { 
	texture = <LightmapTexture>; 
	magfilter = LINEAR; 
	minfilter = LINEAR; 
	mipfilter = LINEAR; 
	AddressU = wrap;
	AddressV = wrap;
};


struct VertexShaderInput
{
    float4 Position: POSITION0;
    float4 Normal: NORMAL0;
    float2 TexCoord1: TEXCOORD0;
    float2 TexCoord2: TEXCOORD1;
};


struct VertexShaderOutput
{
    float4 Position: POSITION0;
    float2 TexCoord1: TEXCOORD0;
    float2 TexCoord2: TEXCOORD1;
	float3 WorldNormal: TEXCOORD2;
};


float4 BlendColorLayers(float4 color1, float4 color2, float4 color3)
{
	float4 color;
	color.rgb = color1.rgb + color2.rgb + color3.rgb;
	color.a = color1.a;
	return color;
}


float4 GetTextureColor(sampler textureSampler, float2 texCoord)
{
	float4 color = tex2D(textureSampler, texCoord);
	color.rgb *= 1.35;
	if (!DisplayTextures) {
		color.rgb = 0.75;
	}
	return color;
}


float4 CalcPhongShading1(float3 normal)
{
	float shading = saturate(dot(normal, -Light1Dir));
	shading = shading * Light1ShadowDepth + (1 - Light1ShadowDepth);
	float4 output;
	output.rgb = Light1Color.rgb * shading;
	output.a = 1;
	return output;
}


float4 CalcPhongShading2(float3 normal)
{
	float shading = saturate(dot(normal, -Light2Dir));
	shading = shading * Light2ShadowDepth + (1 - Light2ShadowDepth);
	float4 output;
	output.rgb = Light2Color.rgb * shading;
	output.a = 1;
	return output;
}


float4 CalcPhongShading3(float3 normal)
{
	float shading = saturate(dot(normal, -Light3Dir));
	shading = shading * Light3ShadowDepth + (1 - Light3ShadowDepth);
	float4 output;
	output.rgb = Light3Color.rgb * shading;
	output.a = 1;
	return output;
}


VertexShaderOutput GenericVS(VertexShaderInput input)
{
    VertexShaderOutput output;
    float4x4 WorldViewProjection = mul(mul(World, View), Projection);
    float3x3 World3x3 = (float3x3)World;
    output.Position = mul(mul(input.Position, RootMatrix), WorldViewProjection);
    output.TexCoord1 = input.TexCoord1;
    output.TexCoord2 = input.TexCoord2;
    float3 normal3 = (float3)input.Normal;
    output.WorldNormal = normalize(mul(normal3, World3x3));
    return output;
}


float4 DiffusePS(VertexShaderOutput input) : COLOR0
{
	float4 diffuseColor = GetTextureColor(DiffuseTextureSampler, input.TexCoord1);
	float4 phongShading1 = CalcPhongShading1(input.WorldNormal);
	float4 phongShading2 = CalcPhongShading2(input.WorldNormal);
	float4 phongShading3 = CalcPhongShading3(input.WorldNormal);
	float4 color1 = diffuseColor * phongShading1;
	float4 color2 = diffuseColor * phongShading2;
	float4 color3 = diffuseColor * phongShading3;
	return BlendColorLayers(color1, color2, color3);
}


float4 DiffuseLightmapPS(VertexShaderOutput input) : COLOR0
{
	float4 diffuseColor = GetTextureColor(DiffuseTextureSampler, input.TexCoord1);
	//if (EnableLightMaps) {
		float4 lightmapColor = tex2D(LightmapTextureSampler, input.TexCoord2);
		diffuseColor *= lightmapColor;
	//}
	float4 phongShading1 = CalcPhongShading1(input.WorldNormal);
	float4 phongShading2 = CalcPhongShading2(input.WorldNormal);
	float4 phongShading3 = CalcPhongShading3(input.WorldNormal);
	float4 color1 = diffuseColor * phongShading1;
	float4 color2 = diffuseColor * phongShading2;
	float4 color3 = diffuseColor * phongShading3;
	return BlendColorLayers(color1, color2, color3);
}


technique Diffuse
{
    pass Pass1
    {
        VertexShader = compile vs_1_1 GenericVS();
        PixelShader = compile ps_2_0 DiffusePS();
    }
}


technique DiffuseLightmap
{
    pass Pass1
    {
        VertexShader = compile vs_1_1 GenericVS();
        PixelShader = compile ps_2_0 DiffuseLightmapPS();
    }
}
