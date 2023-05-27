using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager THIS;
    //public 
    AudioSource audio_scr;
    public AudioClip sound_clickButton;
    public AudioClip sound_getIitem;
    public AudioClip sound_getCoin;
    public AudioClip sound_weapon_main;

    private void Awake() {
        THIS = this;
        audio_scr = GetComponent<AudioSource>();
    }

    public void PlaySound_ClickButton() {
        audio_scr.PlayOneShot(sound_clickButton);
    }

    public void PlaySound_GetItem() {
        audio_scr.PlayOneShot(sound_getIitem);
    }

    public void PlaySound_GetCoin() {
        audio_scr.PlayOneShot(sound_getCoin);
    }

    public void PlaySound_ShotWeapon() {
        audio_scr.PlayOneShot(sound_weapon_main);
    }
 
    public void PlaySound_FootRight()
    {
        audio_scr.PlayOneShot(sound_getCoin);
    }

    public void PlaySound_FootLeft()
    {
        audio_scr.PlayOneShot(sound_weapon_main);
    }

    public void PlaySound_OutOfOxygen()
    {
        audio_scr.PlayOneShot(sound_weapon_main);
    }
}

/*
public class SoundManager : MonoBehaviour
{

    public static SoundManager THIS;

    public AudioSource audio_scr1;

    private void Awake()
    {
        THIS = this;
        audio_scr1 = GetComponent<AudioSource>();
    }

    public void PlaySound_GetItem()
    {
        audio_scr1.Play();
    }
}

*/