using System;
using UnityEngine;

[Serializable]
public class CollectibleTypeSpritePair
{
    [SerializeField] private CollectibleType collectibleType;
    [SerializeField] private Sprite sprite;

    public CollectibleType CollectibleType => collectibleType;
    public Sprite Sprite => sprite;
}