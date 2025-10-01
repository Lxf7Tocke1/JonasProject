using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Damageable : MonoBehaviour
{
    [SerializeField] protected float Health;
    [SerializeField] protected float MaxHealth;
    public bool Alive => Health > 0;
    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TakingDamage();
    }

    public void TakingDamage(float someDamage = 1.0f)
    {
        if (FindAnyObjectByType<Enemy>())
        {
            Health -= someDamage;
            if (Alive == false) Death();
        }
    }

    public void Death()
    {

    }

}