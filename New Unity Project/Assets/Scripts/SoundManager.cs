﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioSource[] audioSource;
    public static Dictionary<string, AudioSource> sounds;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponents<AudioSource>();
        sounds = new Dictionary<string, AudioSource>();

        sounds.Add("DEAD", audioSource[0]);
        sounds.Add("DEFEATED", audioSource[1]);
        sounds.Add("SPELLCARD", audioSource[2]);
        sounds.Add("1635", audioSource[3]);
    }


    //ex      SoundManager.sounds["Effect_Jump"].Play();

}
