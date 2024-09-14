using UnityEngine;
using UnityEngine.UI;

public class ButtonCreator : MonoBehaviour
{
    void Start()
    {
        // Create a Canvas if not already present
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas == null)
        {
            GameObject canvasObject = new GameObject("Canvas");
            canvas = canvasObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvasObject.AddComponent<CanvasScaler>();
            canvasObject.AddComponent<GraphicRaycaster>();
        }

        // Create 3 buttons in a vertical column, aligned to the top-right corner
        CreateButton("Button1", new Vector2(-60, -20), "Take Canister", () => ButtonClicked("Take Canister"), canvas);
        CreateButton("Button2", new Vector2(-60, -60), "Notify Police", () => ButtonClicked("Notify Police"), canvas);
        CreateButton("Button3", new Vector2(-60, -100), "Flee", () => ButtonClicked("Flee"), canvas);
    }

    // Method to create a button
    void CreateButton(string name, Vector2 position, string buttonText, UnityEngine.Events.UnityAction onClickAction, Canvas canvas)
    {
        // Create a button game object and add it to the canvas
        GameObject buttonObject = new GameObject(name);
        buttonObject.transform.SetParent(canvas.transform, false);

        // Add RectTransform and configure it
        RectTransform rectTransform = buttonObject.AddComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(160, 30); // Button size

        // Align the buttons to the upper-right corner (anchor and pivot)
        rectTransform.anchorMin = new Vector2(1, 1); // Top-right corner
        rectTransform.anchorMax = new Vector2(1, 1); // Top-right corner
        rectTransform.pivot = new Vector2(1, 1);     // Set pivot to the top-right
        rectTransform.anchoredPosition = position;   // Button's position relative to the top-right corner

        // Add a background image to the button
        Image image = buttonObject.AddComponent<Image>();
        image.color = Color.white;

        // Add the Button component
        Button button = buttonObject.AddComponent<Button>();

        // Add button text
        GameObject textObject = new GameObject("Text");
        textObject.transform.SetParent(buttonObject.transform, false);

        Text text = textObject.AddComponent<Text>();
        text.text = buttonText;
        text.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        text.alignment = TextAnchor.MiddleCenter;
        text.color = Color.black; // Set text color to black

        // Adjust RectTransform for the text
        RectTransform textRectTransform = textObject.GetComponent<RectTransform>();
        textRectTransform.sizeDelta = rectTransform.sizeDelta;
        textRectTransform.anchoredPosition = Vector2.zero;

        // Add button click event
        button.onClick.AddListener(onClickAction);
    }

    // What happens when a button is clicked
    void ButtonClicked(string buttonText)
    {
        Debug.Log(buttonText + " clicked!");
    }
}
