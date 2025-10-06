using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : Damageable
{
    [SerializeField] float PlayerSpeed;
    [SerializeField] Vector3 movement;

    [SerializeField] Image healthBar;
    [SerializeField] TextMeshProUGUI healthText;

    [SerializeField] Image EXPBar;
    [SerializeField] TextMeshProUGUI EXPText;

    [SerializeField] GameObject DeadFish_Prefab;
    [SerializeField] private float Experience = 0f;
    [SerializeField] private float MaxExperience = 100;


    void Start()
    {
        MaxHealth = 100f;
        Health = MaxHealth;
        CurrentExp = 0;
        PlayerLevel = 1;
        LevelUpEXP = 10;
    }

    public void UpdatePlayer()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement = new Vector3(x, y, 0);

        transform.position += movement.normalized * Time.deltaTime * PlayerSpeed;

        healthText.text = Health.ToString() + " / " + MaxHealth.ToString();
        healthBar.fillAmount = Health / MaxHealth;

        EXPText.text = Experience.ToString() + " / " + MaxExperience.ToString();
        EXPBar.fillAmount = Experience / MaxExperience;


        Shooting();
    }

    public void GainXP(float someAmount)
    {
        CurrentExp += someAmount;
        if ((LevelUpEXP / CurrentExp) <= 1)
            PlayerLevelUp();
    }
    public void PlayerLevelUp()


    {
        PlayerLevel++;
        LevelUpEXP *= 1.1f;
        CurrentExp = 0;
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
    public override void Death()
    {
        SceneManager.LoadScene("MainScene");
    }
}
