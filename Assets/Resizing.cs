using UnityEngine;

public class Resizing : MonoBehaviour
{
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
//Note: this is for Non - UI objects only - I use it for my player and Fruit objects, as well as other animation sprites.