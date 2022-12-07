using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertCommand : MonoBehaviour
{
    public static void InvertControls(bool isInvert)
    {
        if (isInvert)
        {
            Camera.main.transform.localRotation = Quaternion.Euler(new Vector3(45f, 180f, 180f));
        }
        else
        {
            Camera.main.transform.localRotation = Quaternion.Euler(new Vector3(45f, 180f, 0f));
        }
    }
}
