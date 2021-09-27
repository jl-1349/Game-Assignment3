using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    public AudioClip BackgroundMusic;
    public AudioClip normalMusic;
    bool isPlayMusic;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().clip = BackgroundMusic;
        GetComponent<AudioSource>().Play();
        isPlayMusic = true;

    }
    // Update is called once per frame
    void Update()
    {
        if (isPlayMusic)
        {
            isPlayMusic = false;
            Invoke("AudioChange", 3.0f);
        }

    }

    void AudioChange()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().clip = normalMusic;
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().loop = true;
    }
}
