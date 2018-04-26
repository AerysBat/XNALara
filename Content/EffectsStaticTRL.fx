float4x4 World;
float4x4 View;
float4x4 Projection;

float3 CameraPos;

float3 Light1Dir;
float4 Light1Color;
float Light1ShadowDepth;

float3 Light2Dir;
float4 Light2Color;
float Light2ShadowDepth;

float3 Light3Dir;
float4 Light3Color;
float Light3ShadowDepth;

float BumpShadowAmount;
float BumpSpecularAmount;
float BumpSpecularGloss;

Texture DiffuseTexture;
Texture BumpTexture;

bool DisplayTextures;
bool EnableBumpMaps;


sampler DiffuseTextureSampler = sampler_state { 
	texture = <DiffuseTexture>; 
	magfilter = LINEAR; 
	minfilter = LINEAR; 
	mipfilter = LINEAR; 
	AddressU = wrap;
	AddressV = wrap;
};


sampler BumpTextureSampler = sampler_state { 
	texture = <BumpTexture>; 
	magfilter = LINEAR; 
	minfilter = LINEAR; 
	mipfilter = LINEAR; 
	AddressU = wrap;
	AddressV = wrap;
};


struct VertexShaderBasicInput
{
    float4 Position: POSITION0;
    float4 Normal: NORMAL0;
    float4 Color: COLOR0;
    float2 TexCoord: TEXCOORD0;
};


struct VertexShaderBasicOutput
{
    float4 Position: POSITION0;
    float4 Color: COLOR0;
    float2 TexCoord: TEXCOORD0;
};


struct VertexShaderNextGenInput
{
    float4 Position: POSITION0;
    float4 Normal: NORMAL0;
    float4 Color: COLOR0;
    float2 TexCoord: TEXCOORD0;
    float4 Tangent: TANGENT0;
};


struct VertexShaderNextGenOutput
{
    float4 Position: POSITION0;
    float4 Color: COLOR0;
    float2 TexCoord: TEXCOORD0;
    float3 PositionWorld: TEXCOORD1;
    float3 NormalWorld: TEXCOORD2;
    float3x3 TangentToWorld: TEXCOORD3;
};


float4 BlendColorLayers_2(float4 color1, float4 color2)
{
	float4 color;
	color.rgb = color1.rgb + color2.rgb;
	color.a = color1.a;
	return color;
}


float4 BlendColorLayers_3(float4 color1, float4 color2, float4 color3)
{
	float4 color;
	color.rgb = color1.rgb + color2.rgb + color3.rgb;
	color.a = color1.a;
	return color;
}


float4 GetDiffuseColor(float2 texCoord)
{
	float4 color = tex2D(DiffuseTextureSampler, texCoord);
	if (!DisplayTextures) {
		color.rgb = 0.75;
	}
	return color;
}


float4 BumpShadowFunc(float4 base, float overlay)
{
	float4 output;
	output.rgb = base.rgb * (base.rgb + 2 * overlay * (1 - base.rgb));
	output.a = base.a;
	return output;
}


float3 CalcBumpNormal(float4 bumpColor, VertexShaderNextGenOutput input)
{
	float3 bumpNormalT = float3(bumpColor.rg * 2 - 1, bumpColor.b);	
	return normalize(mul(bumpNormalT, input.TangentToWorld));
}


float CalcPhongShadingFactors_1(float3 normal)
{
	float factor1 = saturate(dot(normal, -Light1Dir));
	return factor1;
}


float2 CalcPhongShadingFactors_2(float3 normal)
{
	float factor1 = saturate(dot(normal, -Light1Dir));
	float factor2 = saturate(dot(normal, -Light2Dir));
	return float2(factor1, factor2);
}


float3 CalcPhongShadingFactors_3(float3 normal)
{
	float factor1 = saturate(dot(normal, -Light1Dir));
	float factor2 = saturate(dot(normal, -Light2Dir));
	float factor3 = saturate(dot(normal, -Light3Dir));
	return float3(factor1, factor2, factor3);
}


float4 CalcPhongShadingColor1(float3 normal, float shadingFactor1)
{
	float shading = shadingFactor1;
	shading = lerp(1, shading, Light1ShadowDepth);
	return float4(Light1Color.rgb * shading, 1);
}


float4 CalcPhongShadingColor2(float3 normal, float shadingFactor2)
{
	float shading = shadingFactor2;
	shading = lerp(1, shading, Light2ShadowDepth);
	return float4(Light2Color.rgb * shading, 1);
}


float4 CalcPhongShadingColor3(float3 normal, float shadingFactor3)
{
	float shading = shadingFactor3;
	shading = lerp(1, shading, Light3ShadowDepth);
	return float4(Light3Color.rgb * shading, 1);
}


float CalcBumpSpecularFactors_1(float3 bumpNormal, VertexShaderNextGenOutput input, float phongShadingFactor)
{
	float3 bumpNormal2 = bumpNormal * 2;
	float3 reflLight1Dir = dot(bumpNormal, Light1Dir) * bumpNormal2 - Light1Dir;
	float3 cameraDir = normalize(input.PositionWorld - CameraPos);
	float specularFactor1 = saturate(dot(cameraDir, reflLight1Dir));
	return phongShadingFactor * pow(specularFactor1, BumpSpecularGloss) * BumpSpecularAmount;
}


float2 CalcBumpSpecularFactors_2(float3 bumpNormal, VertexShaderNextGenOutput input, float2 phongShadingFactors)
{
	float3 bumpNormal2 = bumpNormal * 2;
	float3 reflLight1Dir = dot(bumpNormal, Light1Dir) * bumpNormal2 - Light1Dir;
	float3 reflLight2Dir = dot(bumpNormal, Light2Dir) * bumpNormal2 - Light2Dir;
	float3 cameraDir = normalize(input.PositionWorld - CameraPos);
	float specularFactor1 = saturate(dot(cameraDir, reflLight1Dir));
	float specularFactor2 = saturate(dot(cameraDir, reflLight2Dir));
	return phongShadingFactors * pow(float2(specularFactor1, specularFactor2), BumpSpecularGloss) * BumpSpecularAmount;
}


float3 CalcBumpSpecularFactors_3(float3 bumpNormal, VertexShaderNextGenOutput input, float3 phongShadingFactors)
{
	float3 bumpNormal2 = bumpNormal * 2;
	float3 reflLight1Dir = dot(bumpNormal, Light1Dir) * bumpNormal2 - Light1Dir;
	float3 reflLight2Dir = dot(bumpNormal, Light2Dir) * bumpNormal2 - Light2Dir;
	float3 reflLight3Dir = dot(bumpNormal, Light3Dir) * bumpNormal2 - Light3Dir;
	float3 cameraDir = normalize(input.PositionWorld - CameraPos);
	float specularFactor1 = saturate(dot(cameraDir, reflLight1Dir));
	float specularFactor2 = saturate(dot(cameraDir, reflLight2Dir));
	float specularFactor3 = saturate(dot(cameraDir, reflLight3Dir));
	return phongShadingFactors * pow(float3(specularFactor1, specularFactor2, specularFactor3), BumpSpecularGloss) * BumpSpecularAmount;
}


float4 ApplyBumpBlend(float4 diffuseColor, float4 bumpColor, float bumpSpecularFactor)
{
	float4 specular = float4(bumpSpecularFactor, bumpSpecularFactor, bumpSpecularFactor, 0);
	float4 shadowed = BumpShadowFunc(BumpShadowFunc(diffuseColor, 1 - bumpColor.r), 1 - bumpColor.g);
	return saturate(lerp(diffuseColor, shadowed, BumpShadowAmount) + specular);
}

VertexShaderBasicOutput BasicVS(VertexShaderBasicInput input)
{
    float4x4 WorldViewProjection = mul(mul(World, View), Projection);

    VertexShaderBasicOutput output;
    output.Position = mul(input.Position, WorldViewProjection);
    output.Color = input.Color;
    output.TexCoord = input.TexCoord;
    return output;
}


VertexShaderNextGenOutput NextGenVS(VertexShaderNextGenInput input)
{
    float4x4 ViewProjection = mul(View, Projection);
    
    VertexShaderNextGenOutput output;
    
    float4x4 fullTransform = World;    
    float4 positionWorld = mul(input.Position, fullTransform);
    
    output.Position = mul(positionWorld, ViewProjection);
    output.Color = input.Color;
    output.TexCoord = input.TexCoord;

    output.PositionWorld = positionWorld;
    output.NormalWorld = normalize(mul(input.Normal, (float3x3) fullTransform));
    
    float3 tangentU = normalize(input.Tangent);
    float3 tangentV = normalize(cross(input.Normal, tangentU) * input.Tangent.w);
    float3 normal = normalize(input.Normal);
    
    output.TangentToWorld = mul(float3x3(tangentU, tangentV, normal), fullTransform);
    return output;
}


float4 BasicPS(VertexShaderBasicOutput input) : COLOR0
{
	float4 diffuseColor = GetDiffuseColor(input.TexCoord);
	diffuseColor *= input.Color;
	return diffuseColor;
}


float4 NextGenPS_1(VertexShaderNextGenOutput input) : COLOR0
{
	float4 diffuseColor = GetDiffuseColor(input.TexCoord);
	diffuseColor *= input.Color;
	float phongShadingFactor = CalcPhongShadingFactors_1(input.NormalWorld);
	float4 phongShadingColor1 = CalcPhongShadingColor1(input.NormalWorld, phongShadingFactor);
	float4 bumpColor;
	if (EnableBumpMaps) {
		bumpColor = tex2D(BumpTextureSampler, input.TexCoord);
	}
	else {
		bumpColor = float4(0.5, 0.5, 1, 1);
	}
	float3 bumpNormal = CalcBumpNormal(bumpColor, input);
	float bumpSpecularFactor = CalcBumpSpecularFactors_1(bumpNormal, input, phongShadingFactor);
	float4 color1 = ApplyBumpBlend(diffuseColor, bumpColor, bumpSpecularFactor) * phongShadingColor1;
	return color1;
}


float4 NextGenPS_2(VertexShaderNextGenOutput input) : COLOR0
{
	float4 diffuseColor = GetDiffuseColor(input.TexCoord);
	diffuseColor *= input.Color;
	float2 phongShadingFactors = CalcPhongShadingFactors_2(input.NormalWorld);
	float4 phongShadingColor1 = CalcPhongShadingColor1(input.NormalWorld, phongShadingFactors[0]);
	float4 phongShadingColor2 = CalcPhongShadingColor2(input.NormalWorld, phongShadingFactors[1]);
	float4 bumpColor;
	if (EnableBumpMaps) {
		bumpColor = tex2D(BumpTextureSampler, input.TexCoord);
	}
	else {
		bumpColor = float4(0.5, 0.5, 1, 1);
	}
	float3 bumpNormal = CalcBumpNormal(bumpColor, input);
	float2 bumpSpecularFactors = CalcBumpSpecularFactors_2(bumpNormal, input, phongShadingFactors);
	float4 color1 = ApplyBumpBlend(diffuseColor, bumpColor, bumpSpecularFactors[0]) * phongShadingColor1;
	float4 color2 = ApplyBumpBlend(diffuseColor, bumpColor, bumpSpecularFactors[1]) * phongShadingColor2;
	return BlendColorLayers_2(color1, color2);
}


float4 NextGenPS_3(VertexShaderNextGenOutput input) : COLOR0
{
	float4 diffuseColor = GetDiffuseColor(input.TexCoord);
	diffuseColor *= input.Color;
	float3 phongShadingFactors = CalcPhongShadingFactors_3(input.NormalWorld);
	float4 phongShadingColor1 = CalcPhongShadingColor1(input.NormalWorld, phongShadingFactors[0]);
	float4 phongShadingColor2 = CalcPhongShadingColor2(input.NormalWorld, phongShadingFactors[1]);
	float4 phongShadingColor3 = CalcPhongShadingColor3(input.NormalWorld, phongShadingFactors[2]);
	float4 bumpColor;
	if (EnableBumpMaps) {
		bumpColor = tex2D(BumpTextureSampler, input.TexCoord);
	}
	else {
		bumpColor = float4(0.5, 0.5, 1, 1);
	}
	float3 bumpNormal = CalcBumpNormal(bumpColor, input);
	float3 bumpSpecularFactors = CalcBumpSpecularFactors_3(bumpNormal, input, phongShadingFactors);
	float4 color1 = ApplyBumpBlend(diffuseColor, bumpColor, bumpSpecularFactors[0]) * phongShadingColor1;
	float4 color2 = ApplyBumpBlend(diffuseColor, bumpColor, bumpSpecularFactors[1]) * phongShadingColor2;
	float4 color3 = ApplyBumpBlend(diffuseColor, bumpColor, bumpSpecularFactors[2]) * phongShadingColor3;
	return BlendColorLayers_3(color1, color2, color3);
}


float4 ShadelessPS(VertexShaderBasicOutput input) : COLOR0
{
	float4 color = tex2D(DiffuseTextureSampler, input.TexCoord);
	if (!DisplayTextures) {
		color.rgb = 1.0;
	}
	return color;
}


technique Basic
{
    pass Pass1
    {
        VertexShader = compile vs_2_0 BasicVS();
        PixelShader = compile ps_2_0 BasicPS();
    }
}


technique NextGen_1
{
    pass Pass1
    {
        VertexShader = compile vs_1_1 NextGenVS();
        PixelShader = compile ps_2_0 NextGenPS_1();
    }
}


technique NextGen_2
{
    pass Pass1
    {
        VertexShader = compile vs_2_0 NextGenVS();
        PixelShader = compile ps_2_0 NextGenPS_2();
    }
}


technique NextGen_3
{
    pass Pass1
    {
        VertexShader = compile vs_3_0 NextGenVS();
        PixelShader = compile ps_3_0 NextGenPS_3();
    }
}


technique Shadeless
{
    pass Pass1
    {
        VertexShader = compile vs_2_0 BasicVS();
        PixelShader = compile ps_2_0 ShadelessPS();
    }
}
