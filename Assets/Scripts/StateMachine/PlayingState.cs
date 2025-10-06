using UnityEngine;

public class PlayingState : State
{
  [SerializeField] private  Player player;
  [SerializeField] private EnemySpawner enemyspawner;

  
    public override void UpdateState()
    {
        base.UpdateState();

        player?.UpdatePlayer();
        enemyspawner?.UpdateEnemySpawner();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GamesManager.Instance.SwitchState<PauseState>();
        }
    }
}