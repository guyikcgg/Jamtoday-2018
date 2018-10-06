using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestCanvas : MonoBehaviour {

    public GameObject barraRoja, barraAzul;
    float contador;
	void Start () {
	}
	
    public void UpdateSlider(float fake, float truth)
    {
        UpdateSliderFake(fake);
        UpdateSliderTruth(truth);
    }

    private void UpdateSliderTruth(float percentage)
    {
        if (percentage < 0 || percentage > 100) return;
        barraAzul.GetComponent<Image>().fillAmount = percentage / 100f;
    }

    private void UpdateSliderFake(float percentage)
    {
        if (percentage < 0 || percentage > 100) return;
        barraRoja.GetComponent<Image>().fillAmount = percentage / 100f;
    }

    /*
    void Update () {
        contador += 1 * Time.deltaTime;
        contador = contador % 1;
        barraAzul.GetComponent<Image>().fillAmount =contador;

    }
    */
}
