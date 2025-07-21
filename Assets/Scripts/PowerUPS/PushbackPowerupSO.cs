using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Pushback Powerup")]
public class PushbackPowerupSO : Powerup
{
    public float pushForce = 10f;
    public float pushRadius = 5f;

    public override void Activate(GameObject user)
    {
        Vector2 userPos = user.transform.position;

        foreach (PlayerSwapController player in PlayerSwapController.allPlayers)
        {
            if (player.gameObject == user) continue;

            Vector2 otherPos = player.transform.position;

            bool isBehind = otherPos.x < userPos.x;
            float distance = Vector2.Distance(userPos, otherPos);

            if (isBehind && distance <= pushRadius)
            {
                Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    Vector2 pushDirection = (otherPos - userPos).normalized;
                    Vector2 push = pushDirection * pushForce;

                    rb.AddForce(push, ForceMode2D.Impulse);
                }
            }
        }
    }
}
