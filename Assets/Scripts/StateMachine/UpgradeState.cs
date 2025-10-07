using UnityEngine;

public class UpgradeState : State
{
    [SerializeField] GameObject upgradeMenuUI;
    public override void EnterState()
    {
        base.EnterState();
        upgradeMenuUI.SetActive(true);
    }
    public override void ExitState()
    {
        base.ExitState();
        upgradeMenuUI.SetActive(false);
    }
}
