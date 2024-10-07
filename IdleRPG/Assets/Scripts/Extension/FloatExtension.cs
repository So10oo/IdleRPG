using UnityEngine;

public static class FloatExtension
{
    public static int ToInt(this float f)
    {
        float probability = f % 1;
        int result = Mathf.FloorToInt(f) + Random.Range(0, 1) < probability ? 1 : 0;
        return result;
    }
}

