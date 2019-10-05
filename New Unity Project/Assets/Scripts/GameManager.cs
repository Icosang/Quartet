﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float scrollSpeed { get; set; } = -0.5f;
    void Awake() {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
    }
}