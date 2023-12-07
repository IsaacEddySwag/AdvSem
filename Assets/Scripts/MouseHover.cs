using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private TextMeshProUGUI TMPtext;
    public Button button;
    private string originalText;
    private float originalFontSize;

    public string hoverText = "hovertext";
    public float hoverFontSize = 100f;

    void Start()
    {
        TMPtext = GetComponent<TextMeshProUGUI>();
        button = GetComponent<Button>();
        originalText = TMPtext.text;
        originalFontSize = TMPtext.fontSize;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioManager.instance.ReticleSFX();
        Debug.Log("Hover");
        TMPtext.text = hoverText;
        TMPtext.fontSize = hoverFontSize;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TMPtext.text = originalText;
        TMPtext.fontSize = originalFontSize;
    }

    private void OnMouseDown()
    {
        button.onClick.Invoke();
    }
}
