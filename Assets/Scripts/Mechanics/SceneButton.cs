using UnityEngine;

public class SceneButton : MonoBehaviour
{
    public void CallIntroScene()
    {
        SceneLoader.Instance.LoadSceneIntro();
    }
    public void CallTutorialScene()
    {
        SceneLoader.Instance.LoadSceneTutorial();

    }
    public void CallGameScene()
    {
        SceneLoader.Instance.LoadSceneGame();

    }
    public void CallEndScene()
    {
        SceneLoader.Instance.LoadSceneEnd();

    }
}
