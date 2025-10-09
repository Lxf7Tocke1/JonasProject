using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverState : State
{
    [SerializeField] GameObject gameOverState;
    [SerializeField] Player player;

    public override void UpdateState()
    {
        base.UpdateState();
        gameOverState.SetActive(false);


    }
    public void OnPlayButton()
    {
        GamesManager.Instance.SwitchState<PlayingState>();
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainScene");
    }
}