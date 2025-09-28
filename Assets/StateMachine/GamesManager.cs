using UnityEngine;

public class GamesManager : StateMachine
{
    [SerializeField] Enemy enemy;
    [SerializeField] PlayerMovement movement;
    public static GamesManager Instance;

    private void Awake()
    {
        Instance = this;
        states.Add(new PlayingState(movement, enemy));
        states.Add(new PauseState());
        CurrentState = states[0];
    }


    private void Start()
    {
        SwitchState<PlayingState>();
    }

    private void Update()
    {
        UpdateStateMachine();
    }
}