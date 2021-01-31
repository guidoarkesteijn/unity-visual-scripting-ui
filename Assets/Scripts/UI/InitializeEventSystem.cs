using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class InitializeEventSystem
{
    [RuntimeInitializeOnLoadMethod]
    static void Initialize()
    {
        GameObject go = new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule));
        Object.DontDestroyOnLoad(go);
    }
}
