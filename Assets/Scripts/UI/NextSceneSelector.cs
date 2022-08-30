using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneSelector : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;

    public void LoadNextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
