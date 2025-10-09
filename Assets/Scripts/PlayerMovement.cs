using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float PlayerSpeed;
    [SerializeField] Vector3 movement;
    private void Start()
    {
        PlayerSpeed = 1;
    }

    public void UpdateMovement()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement = new Vector3(x, y, 0);

        transform.position += movement.normalized * Time.deltaTime * PlayerSpeed;

    }
}