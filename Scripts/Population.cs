using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Population : MonoBehaviour {

    public float totalPercentage;
    private float fakePercentage;
    private float truthPercentage;

    public int increment = 5;

    public Population strongAgainst;
    public Population weakAgainst;

    public string populationName;
    public int comboLength;

	void Start () {
        strongAgainst = weakAgainst = null;
	}
	
    public void AddPercentage(Enums.PlayerType type)
    {
        if(fakePercentage + truthPercentage >= 100)
        {
            if(type == Enums.PlayerType.fakeNews)
            {
                fakePercentage += increment;
                truthPercentage -= increment;
            }
            else if(type == Enums.PlayerType.truthNews)
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
    }
}
