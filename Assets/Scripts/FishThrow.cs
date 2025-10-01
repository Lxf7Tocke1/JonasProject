using UnityEngine;

public class FishThrow : MonoBehaviour
{
    Vector3 velocity = new();
    public void Initialize(Vector3 aVelocity, float aSpeed)
    {
        Destroy(gameObject, 100.0f);
        transform.up = aVelocity;
        velocity = aVelocity * aSpeed;
    }
    void Update()
    {
        transform.position += velocity * Time.deltaTime;
    }

}