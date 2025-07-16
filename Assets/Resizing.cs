using UnityEngine;

public class Resizing : MonoBehaviour
{
    public Sprite background;
    //added this so the WebGL wouldn't strip it.
    private Vector3 initialScale;
    private float initialCameraSize;
    void Start()
    {
        initialScale = transform.localScale;
        initialCameraSize = Camera.main.orthographicSize;
    }
    void LateUpdate()
    {
        float scaleFactor = initialCameraSize / Camera.main.orthographicSize;
        transform.localScale = initialScale * scaleFactor;
    }
}