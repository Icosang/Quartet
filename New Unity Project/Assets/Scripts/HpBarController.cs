using UnityEngine;

public class HpBarController : MonoBehaviour
{
    [SerializeField]
    Transform t = null;
    float x, y, z;

    private void Awake()
    {
        x = t.localScale.x;
        y = t.localScale.y;
        z = t.localScale.z;
    }
    public void Scaling(float nowhp)
    {
        t.localScale = new Vector3(nowhp*x, y, z);
    }
    public void PatternEnd() {
        t.localScale = new Vector3(x, y, z);
    }
}
