using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AutoProjectile : MonoBehaviour
{
    Vector3 velocity;
    [SerializeField] float lifeTime = 1f;
    public float damage = 25.0f;
    public void Initialize(Vector3 direction, float speed)
    {
        Destroy(gameObject, lifeTime);

        velocity = direction * speed;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakingDamage(damage);
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        transform.position += velocity * Time.deltaTime;
    }
}
