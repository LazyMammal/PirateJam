using UnityEngine;

public class GameController : MonoBehaviour
{
    public Camera mainCam, fishCam;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            SwitchCamera();
        }
    }

    public void SwitchCamera()
    {
        mainCam.gameObject.SetActive(false);
        fishCam.gameObject.SetActive(true);
    }

    public void PauseGame()
    {
        Time.timeScale = 1f - Time.timeScale;
    }

    public void QuitGame()
    {
        // save any game data here
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}
