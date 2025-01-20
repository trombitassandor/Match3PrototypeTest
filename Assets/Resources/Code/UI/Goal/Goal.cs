using System;
using UnityEngine;

[Serializable]
public class Goal
{
    [SerializeField] private CollectibleType collectibleType;
    [SerializeField] private uint amount;

    public CollectibleType CollectibleType => collectibleType;
    public uint Amount => amount;
}
