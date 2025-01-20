using System;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        foreach (T element in source)
        {
            action(element); 
        }
    }

    public static Quaternion GetRandomRotation()
    {
        return Quaternion.Euler(0, 0, UnityEngine.Random.Range(0, 360));
    }
}
