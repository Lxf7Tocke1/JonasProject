using UnityEditor;
using UnityEngine;

public class PlayingState : State
{
     PlayerMovement playerMovement;
     Enemy enemy;
public PlayingState(PlayerMovement playerMovement, Enemy enemy)
    {
        this.playerMovement = playerMovement;
        this.enemy = enemy;
    }
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