using UnityEngine;

public class SimpleCameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 0f, -10f);

    void Update()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }
}
