using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu, _secondMenu;
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


	public void SwitchMenu()
    {
        if (_mainMenu.activeSelf == true)
        {
            _mainMenu.SetActive(false);
            _secondMenu.SetActive(true);
        }
        else
        {
            _mainMenu.SetActive(true);
            _secondMenu.SetActive(false);
        }
    }

    public void LoadLevelRace()
    {
        SceneManager.LoadScene("nddd");
        
    }

    public void LoadLevelSimulator()
    {
        SceneManager.LoadScene("Hangar_pasha");
    }
}
