using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _spawners;
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private GameObject _mainTower;

    public void OnPlayButtonClick()
    {
        _mainTower.SetActive(true);
        _spawners.SetActive(true);
        _gamePanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
