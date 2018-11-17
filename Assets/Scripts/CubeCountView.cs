using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCountView : MonoBehaviour
{
    void OnGUI()
    {
        GUILayout.Label("CubeCount:" + GameManager.sCubeCount.ToString());
    }
}
