using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    public static GameManagement instance;

    [SerializeField]
    GameObject[] Player;

    private int index;

    public int Index
    {
        get { return index; }
        set { index = value; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    private void OnEnable()
    {
        
        
        SceneManager.sceneLoaded+=OnLevelFinishedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded-=OnLevelFinishedLoading;
    }
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Gameplay")
        {
            Instantiate(Player[index]);
        }
    }


}
