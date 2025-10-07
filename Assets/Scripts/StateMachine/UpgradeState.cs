using UnityEngine;

public class UpgradeState : State
{
    [SerializeField] private UpgradeManager upgradeManager;
    public override void EnterState()
    {
        base.EnterState();
        upgradeManager.ShowUpgradeMenu();
    }
    public override void ExitState()
    {
        base.ExitState();
        upgradeManager.HideUpgradeMenu();
    }
}