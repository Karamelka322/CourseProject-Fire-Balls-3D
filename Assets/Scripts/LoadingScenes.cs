using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScenes : MonoBehaviour
{
    public void LoadScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
