using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] protected float Health;
    [SerializeField] protected float MaxHealth;

    [SerializeField] public float Experience;
    public bool Alive => Health > 0;
    // [SerializeField] protected Player player;
    
    void Start()
    {
       // player = FindAnyObjectByType<Player>();
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


    public virtual void Death()
    {

    }

}