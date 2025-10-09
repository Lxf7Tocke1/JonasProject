using UnityEngine;

public class UpgradeState : State
{
    [SerializeField] GameObject UpgradeMenu;

    [SerializeField] GameObject LeftButton;
    [SerializeField] GameObject MiddleButton;
    [SerializeField] GameObject RightButton;

    [SerializeField] private Player player;
    [SerializeField] private AutoProjectile autoProjectile;

    private float increaseFishThrowDamage = 5f;
    private float increasePlayerMovementSpeed = 0.2f;
    private float increaseAutoProjectileDamage = 3f;
    public override void UpdateState()
    {
        base.UpdateState();
        UpgradeMenu.SetActive(true);

    }
    public void UpgradeFishThrow()
    {
        player.damageFishThrow += increaseFishThrowDamage;
    }
    public void UpgradeAutoShoot()
    {
        autoProjectile.damage = autoProjectile.damage + increaseAutoProjectileDamage;
    }
    public void UpgradePlayerSpeed()
    {
        player.PlayerSpeed += increasePlayerMovementSpeed;
    }

    public void OnBackButton()
    {
        GamesManager.Instance.SwitchState<PlayingState>();
    }
}