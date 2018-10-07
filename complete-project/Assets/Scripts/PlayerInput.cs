using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    //0 fake  1 truth
    private Population[] activePopulation = new Population[2];

    public Population[] populations;

    private Population[] lastPopulation = new Population[2];

    private int[] comboFake;
    private int[] comboTruth;

    private int indexFake, indexTruth = 0;

    private void GenerateCombo(Enums.PlayerType type)
    {
        int type2 = -1;
        if (type == Enums.PlayerType.fakeNews)
            type2 = 0;
        else
            type2 = 1;

        int length = activePopulation[type2].comboLength;
        int random;

        if (type2 == 0)
        {
            comboFake = new int[length];
            indexFake = 0;
        }

        else
        {
            comboTruth = new int[length];
            indexTruth = 0;
        }
            
        for (int i = 0; i < length; i++)
        {
            random = Random.Range(0, 4);
            if (type2 == 0)
                comboFake[i] = random;
            else
                comboTruth[i] = random;
        } 

        if(type2 == 0)
        {
            activePopulation[0].EnableCanvas(Enums.PlayerType.fakeNews, comboFake);
            for(int i=0; i < populations.Length; i++)
            {
                if(activePopulation[0] != populations[i])
                {
                    populations[i].DisableCanvas(Enums.PlayerType.fakeNews);
                }
            }
        }

        else
        {
            activePopulation[1].EnableCanvas(Enums.PlayerType.truthNews, comboTruth);
            for (int i = 0; i < populations.Length; i++)
            {
                if (activePopulation[1] != populations[i])
                {
                    populations[i].DisableCanvas(Enums.PlayerType.truthNews);
                }
            }
        }
    }

    private void CheckCombo(Enums.PlayerType type, int input)
    {
        if (comboFake == null || comboFake.Length <= indexFake) return;
        if (comboTruth == null || comboTruth.Length <= indexTruth) return;

        if (Enums.PlayerType.fakeNews == type)
        {
            if(comboFake[indexFake] == input)
            {
                indexFake++;
                if(comboFake.Length == indexFake)
                {
                    activePopulation[0].AddPercentage(type);
                    GenerateCombo(type);
                }
            }
            else
            {
                GenerateCombo(type);
            }
        }

        else 
        {
            if (comboTruth[indexTruth] == input)
            {
                indexTruth++;
                if (comboTruth.Length == indexTruth)
                {
                    activePopulation[1].AddPercentage(type);
                    GenerateCombo(type);
                }
            }
            else
            {
                GenerateCombo(type);
            }
        }
    }

    void Start () {
        activePopulation[0] = activePopulation[1] = null;
        lastPopulation[0] = lastPopulation[1] = null;
	}
	
	void Update () {

        if(!GameManager.Instance.disableInput)
        {

            float y0 = Input.GetAxis("VerticalFake");
            float y1 = Input.GetAxis("VerticalTruth");

            float x0 = Input.GetAxis("HorizontalFake");
            float x1 = Input.GetAxis("HorizontalTruth");


            #region selection
            if (y0 > 0)
            {
                activePopulation[0] = populations[1];
            }
            else if (y0 < 0)
            {
                activePopulation[0] = populations[3];
            }

            else if (x0 > 0)
            {
                activePopulation[0] = populations[0];
            }
            else if (x0 < 0)
            {
                activePopulation[0] = populations[2];
            }

            if (y1 > 0)
            {
                activePopulation[1] = populations[1];
            }
            else if (y1 < 0)
            {
                activePopulation[1] = populations[3];
            }

            else if (x1 > 0)
            {
                activePopulation[1] = populations[0];
            }
            else if (x1 < 0)
            {
                activePopulation[1] = populations[2];
            }

            if (lastPopulation[0] != activePopulation[0])
            {
                GenerateCombo(Enums.PlayerType.fakeNews);
            }

            if (lastPopulation[1] != activePopulation[1])
            {
                GenerateCombo(Enums.PlayerType.truthNews);
            }

            lastPopulation[0] = activePopulation[0];
            lastPopulation[1] = activePopulation[1];

            #endregion

            #region checkCombo
            if (Input.GetButtonDown("TriangleFake"))
            {
                CheckCombo(Enums.PlayerType.fakeNews, 0);
            }

            else if (Input.GetButtonDown("TriangleTruth"))
            {
                CheckCombo(Enums.PlayerType.truthNews, 0);
            }
            else if (Input.GetButtonDown("CircleFake"))
            {
                CheckCombo(Enums.PlayerType.fakeNews, 1);
            }
            else if (Input.GetButtonDown("CircleTruth"))
            {
                CheckCombo(Enums.PlayerType.truthNews, 1);
            }
            else if (Input.GetButtonDown("SquareFake"))
            {
                CheckCombo(Enums.PlayerType.fakeNews, 3);
            }
            else if (Input.GetButtonDown("SquareTruth"))
            {
                CheckCombo(Enums.PlayerType.truthNews, 3);
            }
            else if (Input.GetButtonDown("CrossFake"))
            {
                CheckCombo(Enums.PlayerType.fakeNews, 2);
            }
            else if (Input.GetButtonDown("CrossTruth"))
            {
                CheckCombo(Enums.PlayerType.truthNews, 2);
            }
            #endregion
        }

    }

}
