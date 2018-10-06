using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {

    //TODO: Add scene management (Menu scene)
	protected virtual void Start()
    {
        SceneManager.LoadScene(1);
    }
}
