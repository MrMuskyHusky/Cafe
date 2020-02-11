using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject gameOver;
    public void NextScene()
    {
        // Goes straight to the next scene when a level is completed or a trigger is called.
        Scene activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.buildIndex + 1);
    }
    public void ResetLevel()
    {
        // Resets the current level of the scene when you hit a trigger or a ui button is pressed.
        Scene activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.buildIndex);
    }
    public void GameOver()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0;
    }
    public void MainMenu(int sceneIndex)
    {
        // Loads the scene that has been selected
        SceneManager.LoadScene(0);
    }
    public void OnApplicationQuit()
    {
        // Quits the unity application
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
