using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasComboController : MonoBehaviour {

    public Image[] buttons;
    public Sprite[] sprites;
    private Canvas cv;
    private int ticked;


    private bool vibrating;

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

    public void BadButton()
    {
        RectTransform button;

        if (cv.enabled == false) return;
        if (buttons == null) return;
        if (ticked >= buttons.Length) return;
        if (vibrating) return;
        vibrating = true;

        button = buttons[ticked].gameObject.GetComponent<RectTransform>();
        StartCoroutine(StartBadButtonAnimation(button, 0.2f));
  
    }

    IEnumerator StartBadButtonAnimation(RectTransform button, float time)
    {
        float deltaY;
        Vector2 initPos = button.position;

        for (float i=0; i<time; i+=Time.deltaTime)
        {
            yield return 0;
            deltaY = 5.0f * Mathf.Sin(2 * Mathf.PI * 3f / 0.2f * i);
            button.position = new Vector2(button.position.x, button.position.y + deltaY);
        }
        button.position = initPos;
        vibrating = false;
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
