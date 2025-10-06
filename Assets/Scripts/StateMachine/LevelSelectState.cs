using UnityEngine;

public class LevelSelectState : State
{
    public override void EnterState()
    {
        base.EnterState();
        gameObject.SetActive(true);
    }
    public override void ExitState()
    {
        base.ExitState();
        gameObject.SetActive(false);
    }
}
