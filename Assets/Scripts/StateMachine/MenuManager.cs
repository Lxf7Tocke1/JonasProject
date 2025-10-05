using UnityEngine;

public class MenuManager : StateMachine
{
    public static MenuManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        SwitchState<MainMenuState>();
    }
    private void Update()
    {
        UpdateStateMachine();
    }
}
