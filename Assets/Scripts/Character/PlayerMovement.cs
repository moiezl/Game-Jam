using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterStats stats;
    private Rigidbody2D rb;
    private float input;

  void Awake()
  {
    stats = Instantiate(stats);
    rb = GetComponent<Rigidbody2D>();

    
    }
  // Update is called once per frame
    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
{
float targetSpeed = input * stats.moveSpeed;
float speedDiff = targetSpeed - rb.velocity.x;

float accelrate = (Mathf.Abs(targetSpeed) > 0.01f) ? stats.acceleration : stats.deceleration;

float movement = Mathf.Pow(Mathf.Abs(speedDiff) * accelrate, 0.9f) * Mathf.Sign(speedDiff);

rb.AddForce(Vector2.right * movement);

}
}





  
