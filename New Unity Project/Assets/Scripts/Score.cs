using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    Text scoreText = null;

    // Update is called once per frame
    void Update()
    {
       scoreText.text = D.Get<GameManager>().score.ToString("D12");
    }
}
