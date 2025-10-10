using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] protected float Health;
    [SerializeField] protected float MaxHealth;

    [SerializeField] public float Experience;
    [SerializeField] protected AudioClip takingDamageClip;

    public bool Alive => Health > 0;
    
    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundFXManager.instance.PlaySoundFXClip(takingDamageClip, transform, 1f);
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