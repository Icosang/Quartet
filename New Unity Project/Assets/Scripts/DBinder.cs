using UnityEngine;

public class DBinder : MonoBehaviour
{
    [SerializeField] MonoBehaviour[] bindTargets = null;

    private bool bindingsAdded;

    void OnValidate()
    {
        foreach (var target in bindTargets)
        {
            if (target == null)
            {
                Debug.Log("There is a null bind target.");
            }
        }
    }

    public void AddBindings()
    {
        if (bindingsAdded)
        {
            return;
        }
        bindingsAdded = true;
        foreach (var target in bindTargets)
        {
            D.AddBinding(target);
        }
    }

    private void OnDestroy()
    {
        foreach (var target in bindTargets)
        {
            D.RemoveBinding(target);
        }
    }
}
