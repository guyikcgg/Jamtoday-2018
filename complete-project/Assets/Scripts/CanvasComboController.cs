using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasComboController : MonoBehaviour {

    public Image[] buttons;
    public Sprite[] sprites;
    private Canvas cv;
    private int ticked;


    private void Start()
    {
        cv = GetComponent<Canvas>();
    }

    // input = population ?
    public void TickButton()
    {
        if (cv.enabled == false) return;
        if (buttons == null) return;
        if (ticked >= buttons.Length) return;
        try
        {
            buttons[ticked++].color = new Color32(255, 255, 225, 130);
        }
        catch
        {
            print("bug!");
        }
    }

    // input = array of random buttons
    public void EnableButtons(int[] input)
    {
        cv.enabled = true;
        for(int i=0; i<input.Length; i++)
        {
            buttons[i].sprite = sprites[input[i]];
            buttons[i].color = new Color32(255, 255, 225, 255);
            ticked = 0;
        }
    }

    public void DisableButtons()
    {
        cv.enabled = false;
    }

}
