using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStats", menuName = "Game/Character Stats")]

public class CharacterStats : ScriptableObject
{
    public float moveSpeed;
    public float acceleration;
    public float deceleration;
}
