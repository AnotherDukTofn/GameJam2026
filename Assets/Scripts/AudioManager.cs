using UnityEngine;

public class AudioManager : MonoBehaviour {
    [SerializeField] private AudioSource sfxAudio;

    public AudioClip HealClip { get; private set; }
    public AudioClip OpenDoorClip {get; private set;}
    public AudioClip fixClip { get; private set; }

    public void PlayAudioClip(AudioClip clip) {
        sfxAudio.clip = clip;
        sfxAudio.PlayOneShot(clip);
    }

    
}
