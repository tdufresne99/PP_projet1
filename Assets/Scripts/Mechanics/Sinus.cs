using System.Collections;
using UnityEngine;

public class Sinus : MonoBehaviour
{
    [SerializeField] private LevelManager _levelManager;
    private Animator _animator;
    private string _levelAnim = "level";
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void PlayAnimation(int level)
    {
        Debug.Log("animation level " + level);
        string anim = _levelAnim + level;
        _animator.SetTrigger(anim);
    }

    public void OnAnimationEnd()
    {
        Debug.Log("Anim done!");
        _levelManager.StartGameAction();
    }
}