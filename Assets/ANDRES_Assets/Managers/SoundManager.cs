using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager THIS;
    //public 
    AudioSource audio_scr;
    public AudioClip sound_clickButton;
    public AudioClip sound_getIitem; // ok
    public AudioClip sound_getCoin; // ok
    public AudioClip sound_weapon_main; // ok
    public AudioClip sound_step_R;
    public AudioClip sound_step_L;
    public AudioClip sound_jump;
    public AudioClip sound_enemy_dies;
    public AudioClip sound_game_over;
    public AudioClip sound_damagePlayer;
    public AudioClip sound_you_win;
    public AudioClip sound_mouse_hover;
    public AudioClip sound_mouse_click;

    // Welcome screen
    public void ByByWelcomeSceneButton() {
        audio_scr.PlayOneShot(sound_weapon_main);
    }


    // Main menu



    // Game

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

    // walk

    //public AudioClip sound_step_R;
    //public AudioClip sound_step_L;

    public void PlaySound_FootRight()
    {
        audio_scr.PlayOneShot(sound_step_R);
    }

    public void PlaySound_FootLeft()
    {
        audio_scr.PlayOneShot(sound_step_L);
    }

    //public AudioClip sound_jump;
    //public AudioClip sound_enemy_dies;
    //public AudioClip sound_game_over
    public void PlaySound_Jump() {
        audio_scr.PlayOneShot(sound_jump);
    }

    public void PlaySound_Enemy_Dies() {
        audio_scr.PlayOneShot(sound_enemy_dies);
    }

    public void PlaySound_GameOver() {
        audio_scr.PlayOneShot(sound_game_over);
    }

    //public AudioClip sound_damagePlayer;
    //public AudioClip sound_you_win;
    //public AudioClip sound_mouse_hover;
    //public AudioClip sound_mouse_click;

    public void PlaySound_DamagePlayer() {
        audio_scr.PlayOneShot(sound_damagePlayer);
    }
    public void PlaySound_YouWin() {
        audio_scr.PlayOneShot(sound_you_win);
    }
    public void PlaySound_MouseHover() {
        audio_scr.PlayOneShot(sound_mouse_hover);
    }
    public void PlaySound_MouseClick() {
        audio_scr.PlayOneShot(sound_mouse_click);
    }


    // -----
    public void PlaySound_OutOfOxygen()
    {
        audio_scr.PlayOneShot(sound_damagePlayer);
    }
}