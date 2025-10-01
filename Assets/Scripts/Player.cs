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


// something is wrong
    [SerializeField] GameObject SpinningSword_Prefab;
    [SerializeField] Transform spinningSword;
    [SerializeField] float Spin_Radius;
    [SerializeField] float Spin_RotationSpeed;
    [SerializeField] float Spin_OrbitSpeed;
    private float currentAngle = 0f;
    void Start()
    {
        MaxHealth = 100f;
        Health = MaxHealth;

       // messed up code
        GameObject spinningweaponInstance = Instantiate(SpinningSword_Prefab, transform.position, Quaternion.identity);
        spinningSword = spinningweaponInstance.transform;
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
        SpinBlade();
        currentAngle += Spin_OrbitSpeed * Time.deltaTime;
    }

    private void Shooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject DeadFish = Instantiate(DeadFish_Prefab, transform.position, Quaternion.identity);
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            Vector3 direction = (mousePosition - transform.position).normalized;

            DeadFish.GetComponent<FishThrow>().Initialize(direction, 4);

        }

    }
    private void SpinBlade()
    {
        // messed up code
        Vector3 orbitPositon = new Vector3(Mathf.Cos(Spin_OrbitSpeed), Mathf.Sin(Spin_OrbitSpeed), 0) * Spin_Radius;

        spinningSword.position = transform.position + orbitPositon;
        spinningSword.Rotate(Vector3.forward * Spin_RotationSpeed * Time.deltaTime);
    }
}
