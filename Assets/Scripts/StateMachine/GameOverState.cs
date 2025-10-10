using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverState : State
{
    [SerializeField] GameObject gameOverState;
    [SerializeField] Player player;

    public override void UpdateState()
    {
        base.UpdateState();
        gameOverState.SetActive(true);


    }
    public void OnPlayButton()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}