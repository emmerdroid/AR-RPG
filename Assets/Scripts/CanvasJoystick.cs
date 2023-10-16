using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasJoystick : MonoBehaviour
{
    public RectTransform inner;
    public RectTransform normalRect;

    private void Awake() {
        normalRect = GetComponent<RectTransform>();
    }
}