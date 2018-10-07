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

    public Image fotaso1, fotaso2;


    public Canvas canvaso1;
    public Sonido sonido;

    public Sonido2 aaaaaaaaaaaaaaaaaaa;

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
        aaaaaaaaaaaaaaaaaaa = FindObjectOfType<Sonido2>();
        StartGameCountdown();
       
    }

    public void StartGameCountdown()
    {
        canvaso1.enabled = false;
        GameManager.Instance.disableInput = true;
        timeLeft = 9;
        StartCoroutine("StartCountdown");
    }

    public void StartGeneralCountdown()
    {
        StartCoroutine("StartMatchCountdown");
    }

    IEnumerator StartCountdown()
    {
        aaaaaaaaaaaaaaaaaaa.PlaySound();
       // timeLeft = 20;
        while (timeLeft >= 0)
        {
            if (timeLeft == 3)
            {
                fotaso2.enabled = false;
                fotaso1.color = new Color(255, 255, 255, 255);
                Destroy(aaaaaaaaaaaaaaaaaaa.gameObject);


            }
            if(timeLeft == 0)
            {
                fotaso1.enabled = false;
            }
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
        GameManager.Instance.disableInput = false;
        StartGeneralCountdown();
        canvaso1.enabled = true;
        sonido.PlayStartSong();
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
        {
            GameManager.Instance.winner = 0;
        }
        else if (fakePercentage < truthPercentage)
            GameManager.Instance.winner = 1;
        else
            GameManager.Instance.winner = 2;

        SceneManager.LoadScene(3);
    }

    public void UpdateSlider()
    {
        SliderCanvas.UpdateSlider(getTotalFakePercentage(), getTotalTruthPercentage());
    }

    public void CloseApplication() {
        Application.Quit();
    }
}
