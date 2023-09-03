using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void SaveItem(string item, object content);

    [DllImport("__Internal")]
    private static extern object LoadItem(string item);

    private void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        SaveItem("teste", 1);
        Debug.Log(LoadItem("teste").ToString());
#endif
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
#if UNITY_WEBGL && !UNITY_EDITOR
        Debug.Log(LoadItem("teste").ToString());
#endif
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
#if UNITY_WEBGL && !UNITY_EDITOR
        Debug.Log(LoadItem("teste2").ToString());
#endif
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
#if UNITY_WEBGL && !UNITY_EDITOR
        SaveItem("teste2", 2);
#endif
        }
    }
}