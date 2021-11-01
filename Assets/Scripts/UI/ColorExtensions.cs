using UnityEngine;
namespace GameCore
{
    public static class ColorExtensions
    {
        public static string ToString (this Color color, bool useAlpha = false, bool fromColor = false)
        {
            string colorName = useAlpha ? ColorUtility.ToHtmlStringRGBA (color) : ColorUtility.ToHtmlStringRGB (color);
            return fromColor ? colorName.ToColor (color) : colorName;
        }
        public static Color With_a (this Color color, float newAlpha)
        {
            color.a = newAlpha;
            return color;
        }

        public static float[] ToArray (this Color color)
        {
            return new float[] { color.r, color.g, color.b, color.a };
        }
    }
}