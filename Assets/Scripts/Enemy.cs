using UnityEngine;

public class Enemy : Damageable
{
    protected Transform target;



    Vector3 EnemyToPlayer;
    [SerializeField] protected float MovementSpeed;
    void Start()
    {
        Health = MaxHealth;
        MovementSpeed = 1f;
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
        FindAnyObjectByType<Player>().AddExperience(2);
        gameObject.SetActive(false);
    }
}