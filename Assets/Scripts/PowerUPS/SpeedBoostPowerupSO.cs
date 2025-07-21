using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Speed Boost Powerup")]
public class SpeedBoostPowerupSO : Powerup
{
    public float speedMultiplier = 1.5f;
    public float duration = 2f;

    public override void Activate(GameObject user)
    {
        PlayerMovement movement = user.GetComponent<PlayerMovement>();
        if (movement != null)
        {
            movement.StartCoroutine(ApplySpeedBoost(movement));
        }
    }
    private IEnumerator ApplySpeedBoost(PlayerMovement movement)
    {
        float originalSpeed = movement.stats.moveSpeed;
        movement.stats.moveSpeed *= speedMultiplier;

        yield return new WaitForSeconds(duration);

        movement.stats.moveSpeed = originalSpeed;
    }
}
