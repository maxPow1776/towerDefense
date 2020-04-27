using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void OnMainMenuButtonClick()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene("RespawnScene", LoadSceneMode.Single);
    }
}
