using UnityEngine;

public class MenuManager : StateMachine
{
    public static MenuManager Instance;

    [SerializeField] private AudioClip mainMenuMusicClip;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        SwitchState<MainMenuState>();
        SoundFXManager.instance.PlaySoundFXClip(mainMenuMusicClip, transform, 1f);
    }
    private void Update()
    {
        UpdateStateMachine();
    }
}
