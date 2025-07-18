using System.Collections;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    [Header("Crumble Settings")]
    [SerializeField] private bool crumble = false;
    [SerializeField] private float crumbleDelay = 0.5f;
    [SerializeField] private float resetTime = 2f;

    [Header("Movement Settings")]
    [SerializeField] private bool rotate = false;
    [SerializeField] private float rotationSpeed = 90f;

    [SerializeField] private bool oscilateX = false;
    [SerializeField] private float speedX = 1;
    [SerializeField] private float sinOffsetX = 0;
    [SerializeField] private float distanceX = 1;

    [SerializeField] private bool oscilateY = false;
    [SerializeField] private float speedY = 1;
    [SerializeField] private float cosOffsetY = 0;
    [SerializeField] private float distanceY = 1;

    private float startX;
    private float startY;
    private float graphTime = 0;
    private Quaternion startRotation;

    void Start()
    {
        startX = transform.position.x;
        startY = transform.position.y;
        startRotation = transform.rotation;
    }

    void Update()
    {
        graphTime+= Time.deltaTime;
        if (oscilateX) OscilationX();
        if (oscilateY) OscilationY();
        if (rotate) Rotate();
    }

    private void OscilationX()
    {
        float xDisplacement = Mathf.Sin((graphTime * speedX) + sinOffsetX) * distanceX;
        transform.position = new Vector3(startX + xDisplacement, transform.position.y, transform.position.z);
    }

    private void OscilationY()
    {
        float yDisplacement = Mathf.Cos((graphTime * speedY) + cosOffsetY) * distanceY;
        transform.position = new Vector3(transform.position.x, startY + yDisplacement, transform.position.z);
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (crumble && collision.collider.CompareTag("Player"))
        {
            StartCoroutine(CrumbleAndRespawn());
        }
    }

    private IEnumerator CrumbleAndRespawn()
    {
        yield return new WaitForSeconds(crumbleDelay);


        // Disable visuals & collider
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;


        graphTime = -resetTime; // Reset graph time to start position
        transform.rotation = startRotation; // Reset rotation
        if (rotate) 
        {
            transform.Rotate(Vector3.forward, rotationSpeed *  -resetTime);
        }
        
        yield return new WaitForSeconds(resetTime);


        // Re-enable visuals & collider
        GetComponent<Collider2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;


    }
}
