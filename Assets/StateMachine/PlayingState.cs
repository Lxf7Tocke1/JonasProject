using UnityEditor;
using UnityEngine;

public class PlayingState : State
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] Enemy enemy;
    public override void UpdateState()
    {
        base.UpdateState();

        playerMovement.UpdateMovement();
        enemy.UpdateEnemy();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GamesManager.Instance.SwitchState<PauseState>();
        }
    }
}