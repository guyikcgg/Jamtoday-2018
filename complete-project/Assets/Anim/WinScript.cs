using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScript : MonoBehaviour {

    public Text[] textos;

    private void Start()
    {
        switch (GameManager.Instance.winner)
        {
            case 0:
                textos[1].enabled = false;
                textos[3].enabled = false;
                break;
            case 1:
                textos[0].enabled = false;
                textos[3].enabled = false;
                break;
            case 2:
                textos[0].enabled = false;
                textos[1].enabled = false;
                textos[2].enabled = false;
                break;
        }
        
    }
}
