using UnityEngine;
using UB.Simple2dWeatherEffects.Standard;

public class CanvasController : MonoBehaviour
{
    public bool ispaused = false;
    GameManager manager;
    UbhTimer timer;
    private void Start()
    {
        manager = D.Get<GameManager>();
        timer = D.Get<UbhTimer>();
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
        if (Input.GetKeyDown(KeyCode.Escape) && !ispaused && manager.isplayscreen) {
            timer.Pause();
            manager.ispausing = true;
            Camera.main.GetComponent<D2FogsNoiseTexPE>().VerticalSpeed = 0f;            
            OnUI(3);
        }
    }
}
