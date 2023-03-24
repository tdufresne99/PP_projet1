using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    private AudioSource _audioSource;

    void Awake()
    {
        if(_instance == null) _instance = this;
        else Destroy(this);
    }

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySoundOneShot(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }

    public void PlaySoundOnLoop(AudioClip clip)
    {
        _audioSource.loop = true;
        _audioSource.clip = clip;
        _audioSource.Play();
    }
    public void PlaySoundOnLoop(AudioClip clip, float time)
    {
        _audioSource.loop = true;
        _audioSource.clip = clip;
        _audioSource.Play();

        Invoke("StopSoundOnLoop", time);
    }

    public void StopSoundOnLoop()
    {
        _audioSource.loop = false;
        _audioSource.Stop();
    }

    public static SoundManager Instance => _instance;
    public AudioClip TriangleLockSFX;
    public AudioClip TriangleFailSFX;
    public AudioClip PlayerRotateSFX;
    public AudioClip PlayerShapeShiftSFX;
    public AudioClip BallPulledSFX;
    public AudioClip BallRollingSFX;
}
