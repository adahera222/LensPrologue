Shader "Custom/Lens Cut Out" {
	SubShader {
		Tags { "Queue" = "Geometry-100" }
		Lighting Off
		Cull Off
		
		Pass {
			ZWrite On
			ZTest Less
			ColorMask 0
		}
	}
}