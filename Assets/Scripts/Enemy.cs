using UnityEngine;

public class Enemy : Damageable
{
    protected Transform target;
    [SerializeField] private AudioClip deathSoundClip;
    
    Vector3 EnemyToPlayer;
    [SerializeField] protected float MovementSpeed;

    [SerializeField] GameObject Particle;

    void Start()
    {
        MovementSpeed = 1f;
        if (Player.PlayerLevel > 1)
            Health = MaxHealth * Player.PlayerLevel;
        else Health = MaxHealth;
    }
    public void Initialized(Transform aTarget)
    {
        target = aTarget;
    }
    public virtual void UpdateEnemy(Vector3 target)
    {
        EnemyToPlayer = (target - transform.position).normalized * Time.deltaTime * MovementSpeed;
        transform.position += EnemyToPlayer;

    }
    public override void Death()
    {
        SoundFXManager.instance.PlaySoundFXClip(deathSoundClip, transform, 1f);
        FindAnyObjectByType<Player>().AddExperience(2);
        Particle.SetActive(true);
        Particle.transform.position = transform.position;
        if (deathSoundClip = null)
        {
            Particle.SetActive(false);
        }
        gameObject.SetActive(false);
    }
}