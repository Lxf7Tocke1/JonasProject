using UnityEngine;

public class GamesManager : StateMachine
{
   
    public static GamesManager Instance;

    [SerializeField] private AudioClip mainMusicClip;

    private void Awake()
    {
        Instance = this;
    }


    private void Start()
    {
        SwitchState<PlayingState>();
        SoundFXManager.instance.PlaySoundFXClip(mainMusicClip, transform, 1f);
    }
    private void Update()
    {
        UpdateStateMachine();
    }
}