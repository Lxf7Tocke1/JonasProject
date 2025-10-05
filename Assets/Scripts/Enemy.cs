using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : Damageable
{
    private Transform target;

   // [SerializeField] Transform PlayerPosition;
    Vector3 EnemyToPlayer;
    [SerializeField] float MovementSpeed;
    void Start()
    {
        Health = MaxHealth;
        MovementSpeed = 1f;
      //  PlayerPosition = FindAnyObjectByType<Player>().transform;
    }
    public void Initialized(Transform aTarget)
    {
        target = aTarget;
    }
    public void UpdateEnemy(Vector3 target)
    {
        EnemyToPlayer = (target - transform.position).normalized * Time.deltaTime * MovementSpeed;
        transform.position += EnemyToPlayer;

    }
    public override void Death()
    {
        FindAnyObjectByType<Player>().GainXP(5);
        gameObject.SetActive(false);
    }
}