using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        int selectedplayer = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        
        GameManagement.instance.Index = selectedplayer;

        SceneManager.LoadScene("Gameplay");
        
    }

    public void ReloadGame()
    {
        //SceneManager.LoadScene("Gameplay");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackHomeScene()
    {

        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
