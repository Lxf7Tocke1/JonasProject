using UnityEngine;

public class OrbitingEnemy : Damageable
{
    Transform playerTarget;

    [SerializeField] private float orbitSpeed = 2f;
    [SerializeField] private float followSpeed = 1f;
    [SerializeField] private float orbitDistance = 4f;
    void Start()
    {
        MaxHealth = 75f;
        Health = MaxHealth;
        playerTarget = FindAnyObjectByType<Player>().transform;
    }

    void Update()
    {
        if (playerTarget != null)
        {
            HandleMovement();
        }
    }

    private void HandleMovement()
    {
        Vector3 directionToPlayer = (playerTarget.position - transform.position).normalized;
        Vector3 orbitDirection = new Vector3(-directionToPlayer.y, directionToPlayer.x, 0);

        float distance = Vector3.Distance(transform.position, playerTarget.position);

        if (distance < orbitDistance)
        {
            transform.position += orbitDirection * orbitSpeed * Time.deltaTime;
        }
        else
        {
            Vector3 combinedMovement = (directionToPlayer + orbitDirection).normalized;
            transform.position += combinedMovement * followSpeed * Time.deltaTime;
        }
    }

    public override void Death()
    {
        playerTarget.GetComponent<Player>().GainXP(10);
        Destroy(gameObject);
    }
}
