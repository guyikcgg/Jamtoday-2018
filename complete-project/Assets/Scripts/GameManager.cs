using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {


   
    public bool disableInput = false;
    public int matchTime = 60;

    //TODO: Add scene management (Menu scene)
    protected virtual void Start()
    {
        SceneManager.LoadScene(1);
    }
    
    
}

