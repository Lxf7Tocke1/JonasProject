using UnityEngine;

public class PlayingState : State
{
    [SerializeField] private  Player player;
    [SerializeField] private EnemySpawner enemyspawner;

    [SerializeField] GameObject UpgradeMenu;

  
    public override void UpdateState()
    {
        base.UpdateState();

        UpgradeMenu.SetActive(false);
        player?.UpdatePlayer();
        enemyspawner?.UpdateEnemySpawner();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GamesManager.Instance.SwitchState<PauseState>();
        }
        if (player.PlayerLevel > player.PreviousLevel)
        {
            player.PreviousLevel = player.PlayerLevel;
            GamesManager.Instance.SwitchState<UpgradeState>();

        }
    }
}