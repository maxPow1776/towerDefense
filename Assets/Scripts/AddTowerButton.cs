using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AddTowerButton : MonoBehaviour
{
    [SerializeField] private GameObject _panelHelper;
    public float _interval;

    public void OnAddTowerButtonClick()
    {
            StartCoroutine(ButtonClick());
    }

    IEnumerator ButtonClick()
    {
        gameObject.GetComponent<Button>().interactable = false;
        gameObject.GetComponent<Button>().interactable = false;
        _panelHelper.SetActive(true);
        yield return new WaitForSeconds(_interval);
        gameObject.GetComponent<Button>().interactable = true;
    }
}
