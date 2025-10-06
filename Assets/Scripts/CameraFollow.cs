using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    Vector3 cameraOffset = new Vector3(0, 0, -10);
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = target.position + cameraOffset;
    }
}
