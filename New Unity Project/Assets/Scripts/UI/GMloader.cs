using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GMloader : MonoBehaviour
{    private void Awake()
    {
        StartCoroutine(LoadGM());
    }
    IEnumerator LoadGM()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("GameManager", LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
