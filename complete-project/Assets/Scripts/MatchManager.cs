using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchManager : MonoBehaviour {

    public int timeLeft = 60;
    public int matchTime = 60;

    public Population[] populations;

    void OnEnable () {
        SceneManager.sceneLoaded += OnSceneLoaded;
	}

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartGameCountdown();
    }

    public void StartGameCountdown()
    {
        GameManager.Instance.disableInput = true;
        timeLeft = 3;
        StartCoroutine("StartCountdown");
    }

    public void StartGeneralCountdown()
    {
        StartCoroutine("StartMatchCountdown");
    }

    IEnumerator StartCountdown()
    {
        while (timeLeft >= 0)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
        GameManager.Instance.disableInput = false;
        StartGeneralCountdown();
    }

    IEnumerator StartMatchCountdown()
    {
        while (matchTime >= 0)
        {
            yield return new WaitForSeconds(1);
            matchTime--;
        }
        CheckWinner();
    }

    private void CheckWinner()
    {
        float fakePercentage = 0;
        float truthPercentage = 0;

        for(int i=0; i < populations.Length; i++)
        {
            fakePercentage += populations[i].totalPercentage * populations[i].fakePercentage / 100;
            truthPercentage += populations[i].totalPercentage * populations[i].truthPercentage / 100;
        }

        if (fakePercentage > truthPercentage)
            Debug.Log("Ganador Fake!1");
        else
            Debug.Log("Ganador truth");
    }


}
