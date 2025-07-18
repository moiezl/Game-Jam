using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    [SerializeField]
    private float bounceForce = 10f;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
    }

}
