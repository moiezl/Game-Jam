using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerupHolder : MonoBehaviour



{
public Powerup currentPowerup;

    void Update()
    {
        if (currentPowerup != null && Input.GetKeyDown(KeyCode.E))
        {
            currentPowerup.Activate(gameObject);
            currentPowerup = null; // remove after use
        }
    }

    public void GivePowerup(Powerup newPowerup)
    {
        if(currentPowerup == null)
        {
            currentPowerup = newPowerup;
            Debug.Log($"Picked up: {newPowerup.powerupName}");
        }
    }
}
