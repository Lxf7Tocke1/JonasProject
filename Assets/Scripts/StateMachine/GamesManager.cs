using UnityEngine;

public class GamesManager : StateMachine
{
   
    public static GamesManager Instance;



    private void Awake()
    {
        Instance = this;
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