using TMPro;
using UnityEngine;

public class MenuManager : StateMachine
{
    public static MenuManager Instance;
    [SerializeField] TextMeshProUGUI highScoreText;

    [SerializeField] private AudioClip mainMenuMusicClip;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        SwitchState<MainMenuState>();

        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "HighScore: " + highScore.ToString();

        SoundFXManager.instance.PlaySoundFXClip(mainMenuMusicClip, transform, 1f);
    }
    private void Update()
    {
        UpdateStateMachine();
    }
}
