using UnityEngine;

public static class BHelper
{
    public static Color LerpColor(Color colorA, Color colorB, float percentage)
    {
        if (colorA != colorB)
            return Color.Lerp(colorA, colorB, percentage * Time.deltaTime);
        else
            return colorB;
    }
}
