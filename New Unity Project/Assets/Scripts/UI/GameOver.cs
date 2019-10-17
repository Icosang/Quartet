using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    void Update() {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.LoadScene("MainMenu");
            // 여러가지 초기화
            D.Get<UbhObjectPool>().ReleaseAllBullet();
            D.Get<GameManager>().scrollSpeed = 0.5f;
            D.Get<UbhTimer>().Resume();
            D.Get<GameManager>().life = 4;
        } 
    }
}
