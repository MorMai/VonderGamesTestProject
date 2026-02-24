using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EntityData", menuName = "ScriptableObjects/EntityData")]
public class EntityData : ScriptableObject
{
    public string EntityName;
    public int health;
    public int minDamage;
    public int maxDamage;
    public int jumpHeight;
    public int moveSpeed;
    public int attackSpeed;
}
