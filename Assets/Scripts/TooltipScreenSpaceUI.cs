using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TooltipScreenSpaceUI : MonoBehaviour
{
    public static TooltipScreenSpaceUI Instance { get; private set; }
    [SerializeField] private RectTransform canvasRectTransform;

    private RectTransform backgroundRectTransform;
    private TextMeshProUGUI textMeshPro;
    private RectTransform rectTransform;

    private void Awake()
    {
        Instance = this;

        backgroundRectTransform = transform.Find("background").GetComponent<RectTransform>();
        textMeshPro = transform.Find("text").GetComponent<TextMeshProUGUI>();
        rectTransform = transform.GetComponent<RectTransform>();

        HideToolTip();

    }
    private void SetText(string tooltipText)
    {
        textMeshPro.SetText(tooltipText);
        textMeshPro.ForceMeshUpdate();

        Vector2 textSize = textMeshPro.GetRenderedValues(false);

        //use the next one for manually setting padding for text on the background
        //Vector2 paddingSize = new Vector2(8, 8);
        //using textMeshPro text Extra Settings margins:
        Vector2 paddingSize = new Vector2(textMeshPro.margin.x * 2, textMeshPro.margin.y * 2+10);

        backgroundRectTransform.sizeDelta = textSize + paddingSize;
    }
    private void Update()
    {
        Vector2 anchoredPosition = Input.mousePosition / canvasRectTransform.localScale.x;

        if (anchoredPosition.x - backgroundRectTransform.rect.width > canvasRectTransform.rect.width)
        {
            // Tooltip left the screen on the right side.
            anchoredPosition.x = canvasRectTransform.rect.width - backgroundRectTransform.rect.width;
        }
        if (anchoredPosition.y - backgroundRectTransform.rect.height > canvasRectTransform.rect.height)
        {
            // Tooltip left the screen on the top side.
            anchoredPosition.y = canvasRectTransform.rect.height - backgroundRectTransform.rect.height;
        }
        //keep tooltip from leaving bottom and left side
        /*
        Rect screenRect = new Rect(0, 0, Screen.currentResolution.width, Screen.currentResolution.height);
        if (anchoredPosition.x < screenRect.x)
        {
            anchoredPosition.x = screenRect.x;
        }

        if (anchoredPosition.y < screenRect.y)
        {
            anchoredPosition.y = screenRect.y;
        }*/

        rectTransform.anchoredPosition = anchoredPosition;
    }
    private void ShowTooltip(string tooltipText)
    {
        gameObject.SetActive(true);
        transform.SetAsLastSibling();
        if (tooltipText == null) 
        {
            tooltipText = "default text";
         }
        SetText(tooltipText); 
    }
    private void HideToolTip()
    {
        gameObject.SetActive(false);
    }
    public static void ShowTooltip_Static(string tooltipText)
    {
        Instance.ShowTooltip(tooltipText);
    }
    public static void HideTooltip_Static()
    {
        Instance.HideToolTip();
    }
}
