using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MatchManager : MonoBehaviour {

    public int timeLeft; // Modify GameObject
    public int matchTime;

    public Text matchtext;

    public TestCanvas SliderCanvas;
    public Population[] populations;

    void OnEnable() {
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
        Population pop;

        while (matchTime >= 0)
        {
            matchtext.text = (matchTime).ToString();
            yield return new WaitForSeconds(1);
            matchTime--;

            for (int i = 0; i < populations.Length; i++)
            {
                pop = populations[i];
                if (matchTime % pop.timeToDecrease > 0) continue;
                if (pop.strongAgainst == null) continue;
                    
                if (pop.fakePercentage >= pop.threshold)
                {
                    pop.strongAgainst.DecreasePercentage(Enums.PlayerType.truthNews);
                }
                else if (pop.truthPercentage >= pop.threshold)
                {
                    pop.strongAgainst.DecreasePercentage(Enums.PlayerType.fakeNews);
                }   
            }
        }
        CheckWinner();
    }

    private float getTotalFakePercentage()
    {
        float ret = 0;
        for (int i = 0; i < populations.Length; i++)
        {
            ret += populations[i].totalPercentage * populations[i].fakePercentage / 100f;
        }
        return ret;
    }

    private float getTotalTruthPercentage()
    {
        float ret = 0;
        for (int i = 0; i < populations.Length; i++)
        {
            ret += populations[i].totalPercentage * populations[i].truthPercentage / 100f;
        }
        return ret;
    }

    private void CheckWinner()
    {
        float fakePercentage = getTotalFakePercentage();
        float truthPercentage = getTotalTruthPercentage();


        if (fakePercentage > truthPercentage)
            Debug.Log("Ganador Fake!1");
        else if (fakePercentage < truthPercentage)
            Debug.Log("Ganador truth");
        else
            Debug.Log("Empate");
    }

    public void UpdateSlider()
    {
        SliderCanvas.UpdateSlider(getTotalFakePercentage(), getTotalTruthPercentage());
    }

}
