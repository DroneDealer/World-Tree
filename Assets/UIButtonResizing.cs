using UnityEngine;

public class UIButtonResizing : MonoBehaviour
{
    private RectTransform childRectTransform;
    private RectTransform parentRectTransform;
    private Vector2 initialSize;
    // Using privates because I'm attaching this to multiple buttons and its annoying to asign them all manually. So the Start method finds them for me
    void Start()
    {
        childRectTransform = GetComponent<RectTransform>();
        parentRectTransform = transform.parent.GetComponent<RectTransform>();
        initialSize = childRectTransform.sizeDelta;
    }
    void LateUpdate()
    {
        if (parentRectTransform != null && childRectTransform != null)
        {
            float parentWidth = parentRectTransform.rect.width / 1920f;
            float parentHeight = parentRectTransform.rect.height / 1080f;
            float scaleFactor = Mathf.Min(parentWidth, parentHeight);
            childRectTransform.sizeDelta = initialSize * scaleFactor;
        }
        else
        {
            Debug.Log("One of your RectTransforms are null!");
        }
    }
}
// This can technically be used for any UI but this is all I needed it for since UI backgrounds seem to size automatically