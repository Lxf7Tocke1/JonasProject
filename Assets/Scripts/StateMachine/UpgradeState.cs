using UnityEngine;

public class UpgradeState : State
{
    [SerializeField] GameObject UpgradeMenu;

    [SerializeField] GameObject LeftButton;
    [SerializeField] GameObject MiddleButton;
    [SerializeField] GameObject RightButton;

    [SerializeField] private Player player;
    [SerializeField] private PlayerMovement playerMovement;


    private float increaseFishThrowDamage = 5f;
    private float increasePlayerMovementSpeed = 1.2f;

    public override void UpdateState()
    {
        base.UpdateState();
        UpgradeMenu.SetActive(true);

    }
    public void UpgradeFishThrow()
    {
        player.damageFishThrow += increaseFishThrowDamage;
    }

    public void UpgradePlayerSpeed()
    {
        playerMovement.PlayerSpeed *= increasePlayerMovementSpeed;
    }

    public void OnBackButton()
    {
        GamesManager.Instance.SwitchState<PlayingState>();
    }
}