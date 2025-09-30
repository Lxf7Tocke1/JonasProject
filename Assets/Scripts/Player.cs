using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : Damageable
{
    [SerializeField] float PlayerSpeed;
    [SerializeField] Vector3 movement;

    [SerializeField] Image healthBar;
    [SerializeField] TextMeshProUGUI healthText;

    [SerializeField] GameObject DeadFish_Prefab;
    void Start()
    {
        MaxHealth = 100f;
        Health = MaxHealth;
    }
    public void UpdatePlayer()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement = new Vector3(x, y, 0);

        transform.position += movement.normalized * Time.deltaTime * PlayerSpeed;

        healthText.text = Health.ToString() + " / " + MaxHealth.ToString();
        healthBar.fillAmount = Health / MaxHealth;

        Shooting();

    }

    private void Shooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject projectile = Instantiate(DeadFish_Prefab, transform.position, Quaternion.identity);
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            Vector3 direction = (mousePosition - transform.position).normalized;

            projectile.GetComponent<FishThrow>().Initialize(direction, 4);

        }

    }
}
