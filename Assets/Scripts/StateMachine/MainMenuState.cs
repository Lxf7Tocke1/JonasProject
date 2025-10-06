
using UnityEngine.SceneManagement;

public class MainMenuState : State
{
    public override void EnterState()
    {
        base.EnterState();
        gameObject.SetActive(true);
    }
    public override void ExitState()
    {
        base.ExitState();
        gameObject.SetActive(false);
    }

    public void OnPlayButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnOptionButton()
    {
        MenuManager.Instance.SwitchState<SettingsState>();
    }

    public void OnSelectLevelButton()
    {
        MenuManager.Instance.SwitchState<LevelSelectState>();
    }
}
