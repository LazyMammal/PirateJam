using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class GameController : MonoBehaviour
{
    public Camera mainCam, fishCam;
    public Transform menuPanel, playButton, resumeButton, restartButton, player, skeletonSpawner;
    private bool isPaused = true, arcadeMode = true;
    private MouseLook mouseLook;

    void Start()
    {
        Time.timeScale = 0f;
        restartButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);
        mouseLook = player.GetComponentInChildren<RigidbodyFirstPersonController>().mouseLook;
        mouseLook.SetCursorLock(!isPaused);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            arcadeMode = !arcadeMode;
            UpdateMode();
        }
    }

    public void WatchDaFishy()
    {
        arcadeMode = false;
        UpdateMode();
        if(isPaused)
            PauseGame();
    }

    public void UpdateMode()
    {
        skeletonSpawner.gameObject.SetActive(arcadeMode);
        mainCam.gameObject.SetActive(arcadeMode);
        fishCam.gameObject.SetActive(!arcadeMode);
    }

    public void PauseGame()
    {
        isPaused = !isPaused;

        menuPanel.gameObject.SetActive(isPaused);
        playButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);

        mouseLook.SetCursorLock(!isPaused);
        Time.timeScale = 1f - Time.timeScale;
    }

    public void RestartGame()
    {
        Scene loadedLevel = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadedLevel.buildIndex);
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
