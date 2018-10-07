using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnotherButton : MonoBehaviour {

    public void CloseApplication()
    {
        Application.Quit();
    }

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => GameManager.Instance.StartGame());
    }
}
