using UnityEngine;

public class FishThrow : MonoBehaviour
{
    Vector3 velocity = new();
    private float damage;
    public void Initialize(Vector3 aVelocity, float aSpeed, float aDamage)
    {
        Destroy(gameObject, 3.0f);
        transform.up = aVelocity;
        velocity = aVelocity * aSpeed;
        damage = aDamage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakingDamage(damage);
        }
    }
    void Update()
    {
        transform.position += velocity * Time.deltaTime;
    }
}