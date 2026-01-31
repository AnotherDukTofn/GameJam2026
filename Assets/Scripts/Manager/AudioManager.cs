using UnityEngine;

public class AudioManager : MonoBehaviour {
    [SerializeField] private AudioSource sfxAudio;
    
    [Header("Audio Clips")]
    [SerializeField] private AudioClip healClip;
    [SerializeField] private AudioClip openDoorClip;
    [SerializeField] private AudioClip fixClip;

    public AudioClip HealClip => healClip;
    public AudioClip OpenDoorClip => openDoorClip;
    public AudioClip FixClip => fixClip;

    public void PlayAudioClip(AudioClip clip) {
        if (clip == null || sfxAudio == null) return;
        sfxAudio.PlayOneShot(clip);
    }
}
