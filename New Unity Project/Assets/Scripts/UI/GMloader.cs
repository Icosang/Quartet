using UnityEngine;
using UnityEngine.SceneManagement;

public class GMloader : MonoBehaviour
{    private void Awake()
    {
        if (D.Get<GameManager>() == null)
            SceneManager.LoadScene("GameManager", LoadSceneMode.Additive);
    }
}
