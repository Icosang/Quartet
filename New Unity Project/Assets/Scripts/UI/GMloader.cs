using UnityEngine;
using UnityEngine.SceneManagement;

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
        }
    }
}