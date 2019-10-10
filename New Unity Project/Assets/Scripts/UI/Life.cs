using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    [SerializeField]
    Text lifeText = null;

    // Update is called once per frame
    void Update()
    {
        if (D.Get<GameManager>().life == 1)
        {
            lifeText.text = "Last Life!!";
        }
        else
            lifeText.text = "Life : " + D.Get<GameManager>().life.ToString();
    }
}

