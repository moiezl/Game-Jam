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
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private bool isCrumbled = false;

    void Start()
    {
        startX = transform.position.x;
        startY = transform.position.y;
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    void Update()
    {
        if (isCrumbled) return;

        if (oscilateX) OscilationX();
        if (oscilateY) OscilationY();
        if (rotate) Rotate();
    }

    void OscilationX()
    {
        float xDisplacement = Mathf.Sin((Time.time * speedX) + sinOffsetX) * distanceX;
        transform.position = new Vector3(startX + xDisplacement, transform.position.y, transform.position.z);
    }

    void OscilationY()
    {
        float yDisplacement = Mathf.Cos((Time.time * speedY) + cosOffsetY) * distanceY;
        transform.position = new Vector3(transform.position.x, startY + yDisplacement, transform.position.z);
    }

    void Rotate()
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

        isCrumbled = true;

        // Disable visuals & collider
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;

        yield return new WaitForSeconds(resetTime);

        // Reset position
        transform.position = originalPosition;
        transform.rotation = originalRotation;

        // Re-enable visuals & collider
        GetComponent<Collider2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;

        isCrumbled = false;
    }
}
