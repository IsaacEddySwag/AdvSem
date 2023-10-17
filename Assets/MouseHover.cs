using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MouseHover : MonoBehaviour
{
    private TextMeshProUGUI text;
    private Button button;
    private string originalText;
    private float originalFontSize;

    public string hoverText = "hovertext";
    public float hoverFontSize = 100f;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        button = GetComponent<Button>();
        originalText = text.text;
        originalFontSize = text.fontSize;
    }

    private void OnMouseEnter()
    {
        Debug.Log("Hover");
        text.text = hoverText;
        text.fontSize = hoverFontSize;
    }

    private void OnMouseExit()
    {
        text.text = originalText;
        text.fontSize = originalFontSize;
    }

    private void OnMouseDown()
    {
        button.onClick.Invoke();

    }
}
