using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---Audio Source ---")]
    [SerializeField] AudioSource musicSource;
    public AudioSource SFXSource;
    public AudioSource SFXSourceLoop;
    [Header("---Audio Clip ---")]
    public AudioClip bg;
    public AudioClip dialogue;
    public AudioClip pickUp;
    public AudioClip clickButton;
    public AudioClip clickNextButton;
    public AudioClip closeToArchButton;
    public AudioClip printProcess;
    public AudioClip PrintEnd;

    private void Start()
    {
        musicSource.clip = bg;//½«±³¾°ÒôÀÖ¸ømusicSourceµÄClip
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
    public void PlaySFXLoop(AudioClip clip)
    {
        SFXSourceLoop.PlayOneShot(clip);
    }


}
