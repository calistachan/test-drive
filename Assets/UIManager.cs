using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text feedbackText;

    public static UIManager instance;

    void Awake() 
    {
        instance = this;
    }

    public void SetFeedbackText(TextStyle style, string text) {
        if(style == TextStyle.RED) {
            feedbackText.color = Color.red;
            feedbackText.text = text;
        } else if(style == TextStyle.GREEN) {
            feedbackText.color = Color.green;
            feedbackText.text = text;
        }
    }
}

public enum TextStyle {
    RED, GREEN
}