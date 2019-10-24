using UnityEngine;

public class HpBarController : MonoBehaviour
{
    [SerializeField]
    Transform t = null;
    float x, y, z;

    private void Start()
    {
        x = t.localScale.x;
        y = t.localScale.y;
        z = t.localScale.z;
    }
    public void Scaling(float nowhp)
    {
        t.localScale = new Vector3(nowhp*x, y, z);
    }
}
