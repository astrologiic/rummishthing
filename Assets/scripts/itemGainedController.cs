using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemGainedController : MonoBehaviour
{

    private static FloatingText itemText;
    private static GameObject canvas;

    public static void Initialize()
    {
        canvas = GameObject.Find("Canvas");
        itemText = Resources.Load<FloatingText>("prefabs/itemGainParentPrefab");
    }

    public static void CreateFloatingText(string text)
    {
        FloatingText instance = Instantiate(itemText);
        instance.transform.SetParent(canvas.transform, false);
        instance.SetText(text);
    }
}
