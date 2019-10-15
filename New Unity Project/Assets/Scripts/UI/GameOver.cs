using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    void Update() {
        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Return)) {
            Time.timeScale = 1;
            SceneManager.LoadScene("MainMenu");
            D.Get<UbhObjectPool>().ReleaseAllBullet();
        } 
    }
}
