using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private GameObject upgradeMenu;
    [SerializeField] private Button upgradeButton1;
    [SerializeField] private Button upgradeButton2;
    [SerializeField] private Button upgradeButton3;

    private Player player;

    private delegate void UpgradeFunction();
    private List<UpgradeFunction> availableUpgrades;

    private void Start()
    {
        player = FindFirstObjectByType<Player>();
        availableUpgrades = new List<UpgradeFunction>
        {
            player.UpgradePlayerSpeed,
            player.UpgradeDeadFishDamage,
            player.UpgradeAutoProjectileFireRate
        };

        upgradeMenu.SetActive(false);
    }

    public void ShowUpgradeMenu()
    {
        upgradeMenu.SetActive(true);
        Time.timeScale = 0f;

        List<UpgradeFunction> selectedUpgrades = GetRandomUpgrades(3);

        SetupUpgradeButton(upgradeButton1, selectedUpgrades[0]);
        SetupUpgradeButton(upgradeButton2, selectedUpgrades[1]);
        SetupUpgradeButton(upgradeButton3, selectedUpgrades[2]);
    }

    private void SetupUpgradeButton(Button button, UpgradeFunction upgrade)
    {
        button.onClick.RemoveAllListeners();
        button.GetComponentInChildren<TextMeshProUGUI>().text = upgrade.Method.Name.Replace("Upgrade", "");
        button.onClick.AddListener(() =>
        {
            upgrade();
            HideUpgradeMenu();
        });
    }

    private List<UpgradeFunction> GetRandomUpgrades(int count)
    {
        List<UpgradeFunction> allUpgrades = new List<UpgradeFunction>(availableUpgrades);
        List<UpgradeFunction> randomUpgrades = new List<UpgradeFunction>();

        for (int i = 0; i < count; i++)
        {
            int randomIndex = Random.Range(0, allUpgrades.Count);
            randomUpgrades.Add(allUpgrades[randomIndex]);
            allUpgrades.RemoveAt(randomIndex);
        }

        return randomUpgrades;
    }

    public void HideUpgradeMenu()
    {
        upgradeMenu.SetActive(false);
        Time.timeScale = 1f;
        GamesManager.Instance.SwitchState<PlayingState>();
    }
}