using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager> {

    public bool disableInput = false;
    public int matchTime = 60;
    public int winner; //0 = fake 1 = truth 2 = tie

    //TODO: Add scene management (Menu scene)
    public void StartGame()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(1);
       
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "LoadingScene")
        {
            StartCoroutine("AnyKey");
        }

        if(scene.name == "EndScene")
        {
            Debug.Log("Guay!!");
        }
    }

    IEnumerator AnyKey()
    {
        while (!Input.anyKeyDown) {
            yield return null;
        }

        SceneManager.LoadScene(2);
    }



}

