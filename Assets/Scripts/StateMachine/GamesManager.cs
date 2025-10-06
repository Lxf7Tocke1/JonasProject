using UnityEngine;

public class GamesManager : StateMachine
{
   
    public static GamesManager Instance;



    private void Awake()
    {
        Instance = this;
        //states.Add(new PlayingState(player, enemyspawner));
        //states.Add(new PauseState());
        //CurrentState = states[0];
    }


    private void Start()
    {
        SwitchState<PauseState>();
    }
    private void Update()
    {
        UpdateStateMachine();
    }
}