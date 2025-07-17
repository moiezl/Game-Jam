using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{


    [SerializeField]
    private bool crumble = false;

    [SerializeField]
    private bool rotate = false;
    [SerializeField]
    private float rotationSpeed = 90f; 

    [SerializeField]
    private bool oscilateX = false;
    [SerializeField]
    private float speedX = 1;
    [SerializeField]
    private float sinOffsetX = 0;
    [SerializeField]
    private float distanceX = 1;

    [SerializeField]
    private bool oscilateY = false;
    [SerializeField]
    private float speedY = 1;
    [SerializeField]
    private float cosOffsetY = 0;
    [SerializeField]
    private float distanceY = 1;

    private float startX;
    private float startY;

    // Start is called before the first frame update
    void Start()
    {
        startX = transform.position.x;
        startY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (oscilateX)
        {
            OscilationX();
        }

        if (oscilateY)
        {
            OscilationY();
        }

        if(rotate) 
        {
            Rotate();
        }
    }
    void OscilationX()
    {
        float xDisplacement = Mathf.Sin((Time.time * speedX) + sinOffsetX) * distanceX;
        transform.position = new Vector3(startX + xDisplacement, transform.position.y, 0);
    }
    void OscilationY()
    {
        float yDisplacement = Mathf.Cos((Time.time * speedY) + cosOffsetY) * distanceY;
        transform.position = new Vector3(transform.position.x, startY + yDisplacement, 0);
    }
    void Rotate()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {   

        if (crumble == true) 
        {
            gameObject.SetActive(false);
            Invoke("ResetPlatform", 1f); 
        }
        
    }

    private void ResetPlatform() 
    {
        gameObject.SetActive(true);
    }




}