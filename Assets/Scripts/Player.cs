using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : Damageable
{
    [SerializeField] float PlayerSpeed;
    Vector3 movement;

    [SerializeField] Image healthBar;
    [SerializeField] TextMeshProUGUI healthText;

    [SerializeField] Image EXPBar;
    [SerializeField] TextMeshProUGUI EXPText;

    [SerializeField] GameObject DeadFish_Prefab;
    [SerializeField] private float Experience = 0f;
    [SerializeField] private float MaxExperience = 100;

    [SerializeField] GameObject autoProjectilePrefab;

    [SerializeField] private float levelUpRequirementMultiplier = 1.1f;

    [SerializeField] public float PreviousLevel;
    private float autoShootTimer;

    public float deadFishDamage = 50.0f;
    public float autoProjectileFireRate = 1f;


    void Start()
    {
        Health = MaxHealth;
        CurrentExp = 0;
        PreviousLevel = 1;
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

        EXPText.text = CurrentExp.ToString() + " / " + LevelUpEXP.ToString();
        EXPBar.fillAmount = CurrentExp / LevelUpEXP;


        Shooting();

        AutoShooting();
    }
    private void Shooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject DeadFish = Instantiate(DeadFish_Prefab, transform.position, Quaternion.identity);
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            Vector3 direction = (mousePosition - transform.position).normalized;

            DeadFish.GetComponent<FishThrow>().Initialize(direction, 4, 25f);


        }
    }

    private void AutoShooting()
    {
        autoShootTimer += Time.deltaTime;
        if (autoShootTimer >= 1f)
        {
           Vector3[] directions = { Vector3.up, Vector3.down, Vector3.left, Vector3.right };
            foreach (Vector3 dir in directions)
            {
                GameObject projectile = Instantiate(autoProjectilePrefab, transform.position, Quaternion.identity);
                projectile.GetComponent<AutoProjectile>().Initialize(dir, 5f);
                autoShootTimer = 0f;
            }
        }
    }
    public override void Death()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void UpgradePlayerSpeed()
    {
        PlayerSpeed *= 1.2f;
    }

    public void UpgradeDeadFishDamage()
    {
        deadFishDamage *= 1.25f;
    }

    public void UpgradeAutoProjectileFireRate()
    {
        autoProjectileFireRate *= 0.8f;
    }
    public void AddExperience()
    {

    }
}