using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public void OnUI(int uinum)
    {
        transform.GetChild(uinum).gameObject.SetActive(true);
    }
    public void OffUI(int uinum)
    {
        transform.GetChild(uinum).gameObject.SetActive(false);
    }
}
