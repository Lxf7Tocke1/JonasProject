using UnityEngine;

public class FishThrow : MonoBehaviour
{
    Vector3 velocity = new();
    [SerializeField] Player player;
    private float damage;
    public void Initialize(Vector3 aVelocity, float aSpeed, float aDamage)
    {
        transform.up = aVelocity;
        velocity = aVelocity * aSpeed;
        damage = player.damageFishThrow + aDamage;
        Destroy(gameObject, 3.0f);
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