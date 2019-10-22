using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timebonus : MonoBehaviour
{

    [SerializeField]
    Text timebonusText = null;

    public void ScoreView(long score) {
        StartCoroutine(Timescorenow(score));
    }
    IEnumerator Timescorenow(long score)
    {
        timebonusText.text = "Time Bonus\n+"+ score.ToString();
        var c = timebonusText.color;
            c.a = 1f;
            timebonusText.color = c;
            yield return new WaitForSeconds(3.0f);
        c = timebonusText.color;
        c.a = 0f;
        timebonusText.color = c;
    }
}
