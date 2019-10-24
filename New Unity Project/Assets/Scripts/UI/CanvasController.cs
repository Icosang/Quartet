using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public void ActiveUI(int uinum)
    {
        transform.GetChild(uinum).gameObject.SetActive(true);
    }
}
