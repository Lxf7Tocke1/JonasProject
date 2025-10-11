using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverState : State
{
    [SerializeField] GameObject gameOverState;
    [SerializeField] Player player;

    private void Start()
    {
    }
    public override void UpdateState()
    {
        base.UpdateState();
        gameOverState.SetActive(true);
    }
    public void OnPlayButton()
    {
        HighscoreUpdate();
        SceneManager.LoadScene("MainScene");
    }
    public void MainMenuButton()
    {
        HighscoreUpdate();
        SceneManager.LoadScene("MainMenu");
    }
    private void HighscoreUpdate()
    {
        int SavedHighscore = PlayerPrefs.GetInt("HighScore", 0);
        if (player.PlayerLevelMainMenu >  SavedHighscore)
        {
            PlayerPrefs.SetInt("HighScore", player.PlayerLevelMainMenu);
        }
    }

}