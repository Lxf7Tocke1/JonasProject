using UnityEngine;

public class FishThrow : MonoBehaviour
{
    Vector3 velocity = new();
    public void Initialize(Vector3 aVelocity, float aSpeed)
    {
        Destroy(gameObject, 3.0f);
        transform.up = aVelocity;
        velocity = aVelocity * aSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakingDamage(50.0f);
        }
    }
            void Update()
    {
        transform.position += velocity * Time.deltaTime;
    }

}