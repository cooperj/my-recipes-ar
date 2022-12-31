using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARLogger;

public class LogTester : MonoBehaviour
{
    void Start()
    {
        LogManager.Instance.LogInfo("HELLO, JOSH");
    }

    void Update()
    {
        LogManager.Instance.LogInfo("Eat Banana");
    }
}
