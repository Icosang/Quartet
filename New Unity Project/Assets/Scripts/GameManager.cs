﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public float scrollSpeed { get; set; } = 0.5f;
    public long score { get; set; } = 0;
    public int life { get; set; } = 4;
    public bool isplayscreen { get; set; } = false;
    public bool timebonus { get; set; } = true;
    public bool ispausing { get; set; } = false;
    public bool isindialogue { get; set; } = false;
    public bool retry { get; set; } = false;
    public bool gameover { get; set; } = false;
    //임시, 이따 지우거나 함
    public bool cleared { get; set; } = false;
    [SerializeField]
    Animator fade = null;
    [SerializeField]
    Animator endure = null;
    
    void Awake() {
        //SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
    }
    public void AddScore(long score) {
        this.score += score;
    }

    public void Fade() {
        StartCoroutine(IFade());
    }

    IEnumerator IFade() {
        fade.SetBool("On", true);
        yield return new WaitForSeconds(5.0f);
        fade.SetBool("On", false);
        yield return null;
    }
    public void Endure()
    {
        StartCoroutine(IEndure());
    }

    IEnumerator IEndure()
    {
        endure.SetBool("On", true);
        yield return null;
    }
}
