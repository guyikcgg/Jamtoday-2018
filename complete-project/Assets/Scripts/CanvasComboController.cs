using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasComboController : MonoBehaviour {

    public Image[] buttons;
    public Sprite[] sprites;
    private Canvas cv;

    private void Start()
    {
        cv = GetComponent<Canvas>();
    }

    public void EnableButtons(int[] input)
    {
        cv.enabled = true;
        for(int i=0; i<input.Length; i++)
        {
            buttons[i].sprite = sprites[input[i]];
        }
    }

    public void DisableButtons()
    {
        cv.enabled = false;
    }

}
