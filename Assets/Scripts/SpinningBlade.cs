using UnityEngine;

public class SpinningBlade : MonoBehaviour
{
    public bool ShouldDestroy = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakingDamage(50.0f);
            if (ShouldDestroy)
                Destroy(gameObject);
        }
    }
}