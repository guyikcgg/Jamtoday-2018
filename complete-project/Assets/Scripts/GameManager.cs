using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager> {

    public bool disableInput = false;
    public int matchTime = 60;

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
    }

    IEnumerator AnyKey()
    {
        while (!Input.anyKeyDown) {
            yield return null;
        }

        SceneManager.LoadScene(2);
    }



}

