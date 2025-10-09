using UnityEngine;

public class PlayingState : State
{
    [SerializeField] private  Player player;
    [SerializeField] private EnemySpawner enemyspawner;

    [SerializeField] GameObject UpgradeMenu;
    [SerializeField] GameObject PauseState;
    [SerializeField] GameObject GameOverState;
  
    public override void UpdateState()
    {
        base.UpdateState();

        UpgradeMenu.SetActive(false);
        PauseState.SetActive(false);
        GameOverState.SetActive(false);
        player?.UpdatePlayer();
        enemyspawner?.UpdateEnemySpawner();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GamesManager.Instance.SwitchState<PauseState>();
        }
        if (Player.PlayerLevel > player.PreviousLevel)
        {
            player.PreviousLevel = Player.PlayerLevel;
            GamesManager.Instance.SwitchState<UpgradeState>();
        }
    }
}