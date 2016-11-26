Shader "LightningGlow"
{
	Properties 
	{
_Color("_Color", Color) = (0.9253731,0.03452887,0.03452887,1)
_GlowBrightness("_GlowBrightness", Range(0,10) ) = 0.5

	}
	
	SubShader 
	{
		Tags
		{
"Queue"="Transparent"
"IgnoreProjector"="False"
"RenderType"="Overlay"

		}

		
Cull Off
ZWrite On
ZTest LEqual
ColorMask RGBA
Fog{
}


		CGPROGRAM
#pragma surface surf BlinnPhongEditor  addshadow alpha decal:add vertex:vert
#pragma target 3.0


float4 _Color;
float _GlowBrightness;

			struct EditorSurfaceOutput {
				half3 Albedo;
				half3 Normal;
				half3 Emission;
				half3 Gloss;
				half Specular;
				half Alpha;
			};
			
			inline half4 LightingBlinnPhongEditor_PrePass (EditorSurfaceOutput s, half4 light)
			{
half3 spec = light.a * s.Gloss;
half4 c;
c.rgb = (s.Albedo * light.rgb + light.rgb * spec);
c.a = s.Alpha;
return c;

			}

			inline half4 LightingBlinnPhongEditor (EditorSurfaceOutput s, half3 lightDir, half3 viewDir, half atten)
			{
				half3 h = normalize (lightDir + viewDir);
				
				half diff = max (0, dot (s.Normal, lightDir));
				
				float nh = max (0, dot (s.Normal, h));
				float spec = pow (nh, s.Specular*128.0);
				
				half4 res;
				res.rgb = _LightColor0.rgb * diff * atten * 2.0;
				res.w = spec * Luminance (_LightColor0.rgb);

				return LightingBlinnPhongEditor_PrePass( s, res );
			}
			
			struct Input {
				float3 viewDir;

			};


			void vert (inout appdata_full v, out Input o) {
float4 VertexOutputMaster0_0_NoInput = float4(0,0,0,0);
float4 VertexOutputMaster0_1_NoInput = float4(0,0,0,0);
float4 VertexOutputMaster0_2_NoInput = float4(0,0,0,0);
float4 VertexOutputMaster0_3_NoInput = float4(0,0,0,0);


			}
			

			void surf (Input IN, inout EditorSurfaceOutput o) {
				o.Normal = float3(0.0,0.0,1.0);
				o.Alpha = 1.0;
				o.Albedo = 0.0;
				o.Emission = 0.0;
				o.Gloss=0.0;
				o.Specular=0.0;
				
float4 Multiply4=float4( 1000) * _Time;
float4 Sin0=sin(Multiply4);
float4 Splat0=Sin0.x;
float4 Lerp0=lerp(float4( 0.8),float4( 1),Splat0);
float4 Multiply2=_Color * _GlowBrightness.xxxx;
float4 Fresnel0=float4( 1.0 - dot( normalize( float4(IN.viewDir, 1.0).xyz), normalize( float4( 0,0,1,0).xyz ) ) );
float4 Pow1=pow(Fresnel0,float4( 0.7));
float4 Invert0= float4(1.0) - Pow1;
float4 Pow0=pow(Invert0,float4( 3));
float4 Multiply1=Multiply2 * Pow0;
float4 Multiply3=Lerp0 * Multiply1;
float4 Master0_0_NoInput = float4(0,0,0,0);
float4 Master0_1_NoInput = float4(0,0,1,1);
float4 Master0_3_NoInput = float4(0,0,0,0);
float4 Master0_4_NoInput = float4(0,0,0,0);
float4 Master0_5_NoInput = float4(1,1,1,1);
float4 Master0_6_NoInput = float4(1,1,1,1);
o.Emission = Multiply3;

				o.Normal = normalize(o.Normal);
			}
		ENDCG
	}
	Fallback "Diffuse"
}