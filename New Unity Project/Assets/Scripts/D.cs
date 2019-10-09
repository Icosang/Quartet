using System.Collections.Generic;
using UnityEngine;

public static class D
{
    private readonly static Dictionary<string, MonoBehaviour> scripts = new Dictionary<string, MonoBehaviour>();

    public static void AddBinding(MonoBehaviour script)
    {
        string key = script.GetType().Name;
        if (scripts.ContainsKey(key))
        {
            scripts[key] = script;
        }
        else
        {
            scripts.Add(key, script);
        }
    }

    public static void RemoveBinding(MonoBehaviour script)
    {
        scripts.Remove(script.GetType().Name);
    }

    public static T TryGet<T>() where T : MonoBehaviour
    {
        return Get<T>(true);
    }

    public static T Get<T>(bool canFail = false) where T : MonoBehaviour
    {
        string key = typeof(T).Name;
        if (!scripts.ContainsKey(key))
        {
            SearchForBinder();
        }
        if (!scripts.ContainsKey(key) && !canFail)
        {
            Debug.Log($"D cannot find class {key}.");
        }
        return scripts.ContainsKey(key) ? (T)scripts[key] : null;
    }

    public static void SearchForBinder()
    {
        GameObject.FindGameObjectWithTag("GameManager")?.GetComponent<DBinder>().AddBindings();
    }
}
