using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _spawners;
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private GameObject _mainTower;

    public void OnPlayButtonClick()
    {
        SceneManager.LoadScene("RespawnScene", LoadSceneMode.Single);
    }
}
