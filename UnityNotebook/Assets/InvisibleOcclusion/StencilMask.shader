Shader "Custom/StencilMask"
{
    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue"="Geometry-1" }

        // Do NOT write depth or color
        ZWrite Off
        ColorMask 0

        Stencil
        {
            Ref 1
            Comp always
            Pass replace
        }

        Pass {}
    }
}
