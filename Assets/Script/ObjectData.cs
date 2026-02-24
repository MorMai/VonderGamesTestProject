using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectData", menuName = "ScriptableObjects/ObjectData")]
public class ObjectData : ScriptableObject
{
    public string objectName;
    public int health;
    public int damage;
    public int jumpHeight;
    public int moveSpeed;
    public int attackSpeed;
}
