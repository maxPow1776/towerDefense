using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void OnMainMenuButtonClick()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene("SampleScene 1", LoadSceneMode.Single);
    }
}
