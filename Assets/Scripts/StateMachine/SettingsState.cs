
using UnityEngine;

public class SettingsState : State
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
    public void SetFullscreen(bool isfullscreen)
        {
        Screen.fullScreen = isfullscreen;

        }
    public void SetVsync(bool enableVsync)
    {
        QualitySettings.vSyncCount = enableVsync ? 1 : 0;
    }
    public void OnBackButton()
    {
        MenuManager.Instance.SwitchState<MainMenuState>();
    }
}
