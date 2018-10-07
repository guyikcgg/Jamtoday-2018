using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MatchManager : MonoBehaviour {

    public int timeLeft = 60;
    public int matchTime = 60;

    public Text matchtext;

    public Population[] populations;

    void OnEnable () {
       // SceneManager.sceneLoaded += OnSceneLoaded;
	}

    private void OnDisable()
    {
       // SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
        //Destroy(FindObjectOfType<Population>().gameObject);
        matchtext.enabled = true;
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
        timeLeft = 3;
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
        matchtext.enabled = true;
        matchtext.text = (matchTime).ToString();
        matchtext.enabled = true;
        
        while (matchTime >= 0)
        {
            matchtext.text = (matchTime).ToString();
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
        else if (fakePercentage < truthPercentage)
            Debug.Log("Ganador truth");
        else
            Debug.Log("Empate");
    }

    public void CloseApplication() {
        Debug.Log("ffdfdfd");
        Application.Quit();
    }
}
