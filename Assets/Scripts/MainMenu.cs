using UnityEngine;
public class MainMenu : MonoBehaviour
{
    public enum MainMenuState
    {
        GameState,
        MainMenu,
        Options,
        LevelSelect
    }


    public MainMenuState State;

    public GameObject GameState;
    public GameObject OptionsUI;
    public GameObject LevelSelectUI;

    public void Update()
    {
        switch (State)
        {
            case MainMenuState.GameState:
                break;
            case MainMenuState.Options:
                break;
            case MainMenuState.LevelSelect:
                break;
        }
    }

    public void SwitchState(int aState)
    {
        SwitchState((MainMenuState)aState);
    }

    public void SwitchState(MainMenuState aState)
    {
        GameState.SetActive(aState == MainMenuState.GameState);
        OptionsUI.SetActive(aState == MainMenuState.Options);
        LevelSelectUI.SetActive(aState == MainMenuState.LevelSelect);

        State = aState;
    }

}