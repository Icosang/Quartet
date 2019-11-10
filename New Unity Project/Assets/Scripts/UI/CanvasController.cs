using UnityEngine;
using UB.Simple2dWeatherEffects.Standard;

public class CanvasController : MonoBehaviour
{
    GameManager manager;
    UbhTimer timer;
    SoundManager soundManager;
    private void Start()
    {
        manager = D.Get<GameManager>();
        timer = D.Get<UbhTimer>();
        soundManager = D.Get<SoundManager>();
    }
    public void OnUI(int uinum)
    {
        transform.GetChild(uinum).gameObject.SetActive(true);
    }
    public void OffUI(int uinum)
    {
        transform.GetChild(uinum).gameObject.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !manager.ispausing && manager.isplayscreen) {
            timer.Pause();
            manager.ispausing = true;
            Camera.main.GetComponent<D2FogsNoiseTexPE>().VerticalSpeed = 0f;            
            OnUI(3);
            soundManager.sounds["Bunnyhop"].Pause();
        }
    }
}
