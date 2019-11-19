using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    GameManager manager;

    private void Start()
    {
        manager = D.Get<GameManager>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.LoadScene("MainMenu");
            //manager.retry = true;
            // 여러가지 초기화
            D.Get<UbhObjectPool>().ReleaseAllBullet();
            D.Get<GameManager>().scrollSpeed = 0.5f;
            D.Get<UbhTimer>().Resume();
            D.Get<GameManager>().life = 4;
            CanvasController cc = D.Get<CanvasController>();
                cc.OffUI(0);
                cc.OffUI(1);
        } 
    }
}
