using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] float Health;
    [SerializeField] float MaxHealth = 10f;


    Transform PlayerPosition;
    Vector3 EnemyToPlayer;
    void Start()
    {
        Health = MaxHealth;
        Speed = 1f;
        PlayerPosition = FindAnyObjectByType<PlayerMovement>().transform;
    }

    public void UpdateEnemy()
    {
        EnemyToPlayer = (PlayerPosition.position - transform.position).normalized * Time.deltaTime * Speed;
        transform.position += EnemyToPlayer;

    }
}