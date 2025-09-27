using UnityEngine;

public class PauseState : State
{
    public override void UpdateState()
    {
        base.UpdateState();

        if(Input.GetKey(KeyCode.Escape))
        {
            GamesManager.Instance.SwitchState<PlayingState>();
        }
    }
}