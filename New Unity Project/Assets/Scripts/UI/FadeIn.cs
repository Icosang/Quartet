using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    [SerializeField]
    Text text = null;
    [SerializeField]
    float fade_rate = 0f;
    [SerializeField]
    bool fadein = true;
    private void Start()
    {
        StartCoroutine(Fade(fade_rate, fadein));
    }
    IEnumerator Fade(float faderate, bool isfadein)
    {
        if (isfadein)
        {            
            for (float f = 0.0f; f <= faderate; f += 0.1f)
            {
                var c = text.color;
                c.a = f;
                text.color = c;
                yield return new WaitForSeconds(0.1f);
            }
        }
        else {
            for (float f = 1.0f; f >= faderate; f -= 0.1f)
            {
                var c = text.color;
                c.a = f;
                text.color = c;
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
