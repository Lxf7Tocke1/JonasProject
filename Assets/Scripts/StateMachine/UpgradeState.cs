using UnityEngine;

public class UpgradeState : State
{
    [SerializeField] GameObject UpgradeMenu;

    [SerializeField] GameObject LeftButton;
    [SerializeField] GameObject MiddleButton;
    [SerializeField] GameObject RightButton;


    public override void UpdateState()
    {
        base.UpdateState();
        UpgradeMenu.SetActive(true);


        
    }
    public void OnBackButton()
    {
        GamesManager.Instance.SwitchState<PlayingState>();
    }
}