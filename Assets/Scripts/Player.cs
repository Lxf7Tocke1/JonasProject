using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : Damageable
{

    [SerializeField] Image healthBar;
    [SerializeField] TextMeshProUGUI healthText;
    void Start()
    {
        MaxHealth = 100f;
        Health = MaxHealth;
    }

    void Update()
    {
        healthText.text = Health.ToString() + " / " + MaxHealth.ToString();
        healthBar.fillAmount = Health / MaxHealth;
    }
}
