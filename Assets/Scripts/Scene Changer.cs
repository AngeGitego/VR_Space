using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Call this function to load MainScene from the WelcomeScene
    public void LoadMainScene()
    {
        Debug.Log("Loading MainScene...");
        SceneManager.LoadScene("MainScene");
    }

    // Call this function to quit the application
    public void QuitApplication()
    {
        Debug.Log("Quitting application...");
        Application.Quit();

        // Note: Application.Quit() does not work in the editor, only in built apps
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
