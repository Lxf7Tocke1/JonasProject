using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : Damageable
{
    [SerializeField] public float PlayerSpeed;
    Vector3 movement;

    [SerializeField] Image healthBar;
    [SerializeField] TextMeshProUGUI healthText;

    [SerializeField] Image EXPBar;
    [SerializeField] TextMeshProUGUI EXPText;

    [SerializeField] GameObject DeadFish_Prefab;
    [SerializeField] public float damageFishThrow;


    [SerializeField] private float CurrentExp;
    [SerializeField] private int LevelUpEXP;
    [SerializeField] public float PlayerLevel;
    [SerializeField] public float PreviousLevel;
    [SerializeField] private float levelUpRequirementMultiplier = 1.1f;

    [SerializeField] GameObject autoProjectilePrefab;
    [SerializeField] private float autoProjectileSpeed;
    [SerializeField] private float autoShootTimer;


    void Start()
    {
        Health = MaxHealth;
        CurrentExp = 0;
        PreviousLevel = 1;
        PlayerLevel = 1;
        LevelUpEXP = 10;
        damageFishThrow = 10f;
        autoProjectileSpeed = 5f;
    }
    public void AddExperience(float Experience)
    {
        CurrentExp = CurrentExp + Experience;
    }
    private void LevelUp()
    {
        if (CurrentExp >= LevelUpEXP)
        {
            PlayerLevel += 1;
            CurrentExp = 0;
            LevelUpEXP = Mathf.RoundToInt(LevelUpEXP * levelUpRequirementMultiplier);
        }
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
        LevelUp();
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

            DeadFish.GetComponent<FishThrow>().Initialize(direction, 4, damageFishThrow);


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
                projectile.GetComponent<AutoProjectile>().Initialize(dir, autoProjectileSpeed);
                autoShootTimer = 0f;
            }
        }
    }
    public override void Death()
    {
        GamesManager.Instance.SwitchState<GameOverState>();
        AudioManager.Audio.AddComponent
    }
}