using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{

    [SerializeField] private int _sceneIntro;
    [SerializeField] private int _sceneTutorial;
    [SerializeField] private int _sceneGame;
    [SerializeField] private int _sceneEnd;
    private static SceneLoader _instance;
    void Awake()
    {
        if(_instance == null) _instance = this;
        else Destroy(this);    
        DontDestroyOnLoad(gameObject);
    }

    public void LoadSceneIntro()
    {
        SceneManager.LoadScene(_sceneIntro);
    }
    public void LoadSceneTutorial()
    {
        SceneManager.LoadScene(_sceneTutorial);
    }
    public void LoadSceneGame()
    {
        SceneManager.LoadScene(_sceneGame);
    }
    public void LoadSceneEnd()
    {
        SceneManager.LoadScene(_sceneEnd);
    }

    public static SceneLoader Instance => _instance;
}