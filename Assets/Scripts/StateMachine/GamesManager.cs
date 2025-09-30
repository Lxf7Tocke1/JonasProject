using UnityEngine;

public class GamesManager : StateMachine
{
    [SerializeField] Player player;
    [SerializeField] EnemySpawner enemyspawner;
    public static GamesManager Instance;

    private void Awake()
    {
        Instance = this;
        states.Add(new PlayingState(player, enemyspawner));
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