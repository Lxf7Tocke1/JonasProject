using UnityEngine;

public class OrbitingEnemy : Enemy
{
    [SerializeField] private float orbitDistance = 5.0f;
    [SerializeField] private float orbitSpeed = 50.0f;

    public override void UpdateEnemy(Vector3 targetPosition)
    {
        if (target != null)
        {
            // Rotate around the player
            transform.RotateAround(target.position, Vector3.forward, orbitSpeed * Time.deltaTime);

            // Maintain the orbit distance
            Vector3 direction = (transform.position - target.position).normalized;
            Vector3 desiredPosition = target.position + direction * orbitDistance;
            transform.position = Vector3.MoveTowards(transform.position, desiredPosition, MovementSpeed * Time.deltaTime);
        }
    }
}