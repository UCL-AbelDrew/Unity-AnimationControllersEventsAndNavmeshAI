using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLog : MonoBehaviour
{
   public void DebugEvent(string eventString)
    {
        Debug.Log(eventString);
    }
}
