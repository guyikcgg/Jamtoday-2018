using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonido : MonoBehaviour {

    public AudioSource aSS;
    public AudioClip otherClip;
    private bool a = false;

    void Start () {
       //s aS = GetComponent<AudioSource>();
	}
	
    public void PlayStartSong()
    {
        aSS.Play();
        a = true;
    }

    private void Update()
    {
        if (!aSS.isPlaying && a)
        {
            aSS.clip = otherClip;
            aSS.Play();
        }
    }
}
