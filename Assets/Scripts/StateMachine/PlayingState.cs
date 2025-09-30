using UnityEditor;
using UnityEngine;

public class PlayingState : State
{
     Player player;
    EnemySpawner enemyspawner;
public PlayingState(Player player, EnemySpawner enemySpawner)
    {
        this.player = player;
        this.enemyspawner = enemySpawner;
    }
    public override void UpdateState()
    {
        base.UpdateState();

        player.UpdatePlayer();
        enemyspawner.UpdateEnemySpawner();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GamesManager.Instance.SwitchState<PauseState>();
        }
    }
}