using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip MenuSong;
    public AudioClip PlayingSong;
    public AudioClip Levelup;
    public AudioClip PlayerDies;
    public AudioClip PlayerManualShoot;
    public AudioClip PlayerAutoShoot;

    private void Start()
    {
        musicSource.clip = MenuSong;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
