using System;
using UnityEngine;

public class TriggerObserver : MonoBehaviour
{
    public Action<Collider2D> OnTriggerEnter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTriggerEnter?.Invoke(collision);
    }
}
