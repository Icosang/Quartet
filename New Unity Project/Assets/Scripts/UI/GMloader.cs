using UnityEngine;
using UnityEngine.SceneManagement;
using UB.Simple2dWeatherEffects.Standard;

public class GMloader : MonoBehaviour
{
    CanvasController cc;
    private void Awake()
    {
        if (D.TryGet<GameManager>() == null)
        {
            SceneManager.LoadScene("GameManager", LoadSceneMode.Additive);
        }        
    }
    private void Start()
    {
        cc = D.Get<CanvasController>();
        if (gameObject.tag == "PlayScreen")
        {
            cc.OnUI(0);
            cc.OnUI(1);
            Camera.main.GetComponent<D2FogsNoiseTexPE>().VerticalSpeed = 0.2f;
        }
    }
}