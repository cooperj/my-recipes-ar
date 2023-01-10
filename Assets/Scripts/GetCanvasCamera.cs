using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCanvasCamera : MonoBehaviour
{
    void Start()
    {
        Canvas canvas = GetComponent<Canvas>();
        canvas.worldCamera = GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<Camera>();
    }
}
