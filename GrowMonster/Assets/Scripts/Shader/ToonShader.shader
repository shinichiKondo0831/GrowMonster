// Upgrade NOTE: upgraded instancing buffer 'Props' to new syntax.

Shader "Custom/ToonShader" {
	Properties{
		_OutlineColor("Outline Color", Color) = (0, 0, 0, 0)
		_OutlineWidth("Outline Width", float) = 0.001
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_RampTex("Ramp", 2D) = "white"{}
	}
		SubShader{
		Tags{ "RenderType" = "Opaque" }
		Tags{ "Queue" = "Geometry" }
		LOD 200

		Cull Front

		CGPROGRAM

#pragma surface surf Lambert vertex:vert
	float4 _MainColor;
	float4 _OutlineColor;
	float _OutlineWidth;

	struct Input {
		float4 vertexColor : COLOR;
	};

	void vert(inout appdata_full v, out Input o) {
		float distance = -UnityObjectToViewPos(v.vertex).z;
		v.vertex.xyz += v.normal * distance * _OutlineWidth;
		o.vertexColor = v.color;
	}

	void surf(Input IN, inout SurfaceOutput o) {
		o.Albedo = _OutlineColor.rgb;
		o.Emission = _OutlineColor.rgb;
	}
	ENDCG

	Cull Back
	CGPROGRAM
#pragma surface surf Lambert
		float4 _MainColor;

	struct Input {
		float4 vertexColor : COLOR;
	};

	void surf(Input IN, inout SurfaceOutput o) {
		o.Albedo = _MainColor;
	}
	ENDCG

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
#pragma surface surf ToonRamp

		// Use shader model 3.0 target, to get nicer looking lighting
#pragma target 3.0

		sampler2D _MainTex;
	sampler2D _RampTex;

	struct Input {
		float2 uv_MainTex;
	};
	fixed4 _Color;

	// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
	// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
	// #pragma instancing_options assumeuniformscaling
	UNITY_INSTANCING_BUFFER_START(Props)
		// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		fixed4 LightingToonRamp(SurfaceOutput s, fixed3 lightDir, fixed atten)
	{
		half d = dot(s.Normal, lightDir) * 0.5 + 0.5;
		fixed3 ramp = tex2D(_RampTex, fixed2(d, 0.5)).rgb;
		fixed4 c;
		c.rgb = s.Albedo * _LightColor0.rgb * ramp;
		c.a = 0;
		return c;
	}


	void surf(Input IN, inout SurfaceOutput o) {
		fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
		o.Albedo = c.rgb;
		o.Alpha = c.a;
	}
	ENDCG
	}
		FallBack "Diffuse"
}
