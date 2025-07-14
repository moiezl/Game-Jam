using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Swap Powerup")]

public class SwapPowerUpSO : Powerup
{
 public override void Activate(GameObject user)
 {
    PlayerSwapController swapper = user.GetComponent<PlayerSwapController>();
    if (swapper != null)
    {
        swapper.SwapWithRandomPlayer();
    }
 }
}
