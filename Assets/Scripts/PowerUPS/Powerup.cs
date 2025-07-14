using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : ScriptableObject
{
    public string powerupName;
    public Sprite icon;

    public abstract void Activate(GameObject user);
}
