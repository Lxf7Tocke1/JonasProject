using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseState : State
{
    [SerializeField] GameObject pauseState;
    public override void UpdateState()
    {
        base.UpdateState();
        pauseState.SetActive(true);
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GamesManager.Instance.SwitchState<PlayingState>();
        }
    }
    public void OnPlayButton()
    {
        GamesManager.Instance.SwitchState<PlayingState>();
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}