using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EquippableItem : MonoBehaviour
{
    public ItemData myData { get; private set; }
    public float cooldown = 1f;
    protected float nextUseTime;
    public virtual void Initialize(ItemData data)
    {
        myData = data;
    }
    public abstract void Use(GameObject user, Transform aimTransform);
    public bool CanUse() => Time.time >= nextUseTime;
}
