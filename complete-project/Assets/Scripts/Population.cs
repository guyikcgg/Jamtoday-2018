using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Population : MonoBehaviour {

    public float totalPercentage;
    public float fakePercentage;
    public float truthPercentage;
    public TestCanvas SliderCanvas;

    public int increment = 5;

    public Population strongAgainst;
    public Population weakAgainst;

    public string populationName;
    public int comboLength;

    public CanvasComboController[] canvas;
    public float threshold = 60;
    public float decreaseAmmount = 5;
    public int timeToDecrease = 5;

    public void EnableCanvas(Enums.PlayerType type, int[] input)
    {
        if(type == Enums.PlayerType.fakeNews)
        {
            canvas[0].EnableButtons(input);
        }
        else
        {
            canvas[1].EnableButtons(input);
        }
    }

    public void DisableCanvas(Enums.PlayerType type)
    {
        if (type == Enums.PlayerType.fakeNews)
        {
            canvas[0].DisableButtons();
        }
        else
        {
            canvas[1].DisableButtons();
        }
    }

    public void AddPercentage(Enums.PlayerType type)
    {
        if (fakePercentage + truthPercentage >= 100)
        {
            if (type == Enums.PlayerType.fakeNews)
            {
                fakePercentage += increment;
                truthPercentage -= increment;
            }
            else if (type == Enums.PlayerType.truthNews)
            {
                fakePercentage -= increment;
                truthPercentage += increment;
            }
        }
        else
        {
            if (type == Enums.PlayerType.fakeNews)
            {
                fakePercentage += increment;
            }
            else if (type == Enums.PlayerType.truthNews)
            {
                truthPercentage += increment;
            }
        }
        if (fakePercentage < 0) fakePercentage = 0;
        if (truthPercentage < 0) truthPercentage = 0;
        if (fakePercentage > 100) fakePercentage = 100;
        if (truthPercentage > 100) truthPercentage = 100;

        if (fakePercentage >= threshold && strongAgainst != null)
        {
            //StartCoroutine("DecreasePercentage");
        }
        else if (truthPercentage >= threshold && strongAgainst != null)
        {
            //StartCoroutine("DecreasePercentage");
        }
        SliderCanvas.UpdateSlider(fakePercentage, truthPercentage);
    }

    /*
    IEnumerator DecreasePercentage()
    {
        if (weakAgainst != null)
        while (fakePercentage >= threshold || truthPercentage >= threshold)
        {
            if (fakePercentage > truthPercentage)
            {
                print("decrease truth");
                // weakAgainst.truthPercentage -= decreaseAmmount;
                weakAgainst.AddPercentage(Enums.PlayerType.fakeNews);
                //if (weakAgainst.truthPercentage < 0) weakAgainst.truthPercentage = 0;
            }
            else if (fakePercentage < truthPercentage)
            {
                print("decrease fake");
                weakAgainst.AddPercentage(Enums.PlayerType.truthNews);
                //weakAgainst.fakePercentage -= decreaseAmmount;
                //if (weakAgainst.fakePercentage < 0) weakAgainst.fakePercentage = 0;
            }
            yield return new WaitForSeconds(timeToDecrease);
        }
    }
    */
}

