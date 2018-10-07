using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sonido2 : MonoBehaviour {

    public AudioSource aS;
    public AudioSource aS2;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlaySound()
    {
        aS.Play();
    }

    public void Destroy1()
    {
        Destroy(this.gameObject);
    }

}
