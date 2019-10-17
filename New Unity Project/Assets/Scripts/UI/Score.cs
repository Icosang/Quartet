using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    Text scoreText = null;

    // Update is called once per frame
    void FixedUpdate()
    {
       scoreText.text = D.Get<GameManager>().score.ToString("D12");
    }
}