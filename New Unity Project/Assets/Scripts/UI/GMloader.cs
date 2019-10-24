using UnityEngine;
using UnityEngine.SceneManagement;

public class GMloader : MonoBehaviour
{
    private void Awake()
    {
        if (D.TryGet<GameManager>() == null)
        {
            SceneManager.LoadScene("GameManager", LoadSceneMode.Additive);
        }        
    }
    private void Start()
    {
        if (gameObject.tag == "PlayScreen")
        {
            D.Get<CanvasController>().ActiveUI(0);
        }
    }
}