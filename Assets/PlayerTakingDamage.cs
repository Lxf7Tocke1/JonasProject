using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTakingDamage : MonoBehaviour
{

    [SerializeField] float Health;
    [SerializeField] float MaxHealth;
    void Start()
    {
        MaxHealth = 100f;
        Health = MaxHealth;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TakingDamage();
    }

    public void TakingDamage()
    {
        if (FindAnyObjectByType<Enemy>())
        {
            Health = Health - 10;
            if (Health <= 0)
            {
                Death();
            }
        }
    }

    public void Death()
    {
  //      SceneManager.LoadScene("MainMenu");
    }

}