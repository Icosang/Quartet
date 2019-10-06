using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    GameManager manager;
    [SerializeField]
    Text scoreText = null;
    void Awake()
    {
        manager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
       scoreText.text = manager.score.ToString("D12");
    }
}
