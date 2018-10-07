using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGuapo : MonoBehaviour {

    public GameObject[] menusesGuapos;
    private int lastMenuGuapo;
    private int tiempaso;

    bool boleano = false;

	void Start () {
        //tiempaso = Random.Range(15f, 22f);
        lastMenuGuapo = Random.Range(0, 4);
        menusesGuapos[lastMenuGuapo].SetActive(true);
        StartCoroutine("StartCountdown");
	}

    IEnumerator StartCountdown()
    {
        tiempaso = Random.Range(9, 11);
        while (tiempaso >= 0)
        {
            yield return new WaitForSeconds(1);
            tiempaso--;
        }
        boleano = true;
    }

    private void Update()
    {
        if (boleano)
        {
            int a = Random.Range(0, 4);
            while(a == lastMenuGuapo)
            {
                a = Random.Range(0, 4);
            }

            menusesGuapos[lastMenuGuapo].SetActive(false);
            menusesGuapos[a].SetActive(true);
            lastMenuGuapo = a;
            boleano = false;
            StartCoroutine("StartCountdown");
        }
    }
}
