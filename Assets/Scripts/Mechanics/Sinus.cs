using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Sinus : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClipLvl1;
    [SerializeField] private AudioClip _audioClipLvl2;
    [SerializeField] private AudioClip _audioClipLvl3;
    [SerializeField] private AudioClip _audioClipLvl4;
    [SerializeField] private AudioClip _audioClipLvl5;
    [SerializeField] private AudioClip _audioClipLvl6;
    [SerializeField] private LevelManager _levelManager;
    private Animator _animator;
    [SerializeField] private AudioSource _audioSource;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.loop = false;
    }
    public void PlayClip(int level)
    {
        AudioClip clip = null;
        switch (level)
        {
            case 1:
                clip = _audioClipLvl1;
                break;

            case 2:
                clip = _audioClipLvl2;
                break;

            case 3:
                clip = _audioClipLvl3;
                break;

            case 4:
                clip = _audioClipLvl4;
                break;

            case 5:
                clip = _audioClipLvl5;
                break;

            case 6:
                clip = _audioClipLvl6;
                break;

            default:
                break;
        }
        if(clip == null)
        {
            Debug.Log("test");
            OnClipEnd();
            return;
        }
        var length = clip.length;
        Debug.Log(clip);
        Debug.Log(_audioSource);

        _audioSource.clip = clip;
        _audioSource.Play();
        Invoke("OnClipEnd", length);
    }

    public void OnClipEnd()
    {
        Debug.Log("clip over");

        _levelManager.StartGameAction();
    }
}