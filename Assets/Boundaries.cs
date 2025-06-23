using UnityEngine;

public class PlayerBoundary : MonoBehaviour
{
    public float padding = 0.5f; // How far from the edge the player can go

    private float minX, maxX, minY, maxY;

    void Start()
    {
        // Get the camera bounds in world space
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));

        minX = bottomLeft.x + padding;
        maxX = topRight.x - padding;
        minY = bottomLeft.y + padding;
        maxY = topRight.y - padding;
    }

    void Update()
    {
        // Clamp position every frame
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minY, maxY);
        transform.position = clampedPosition;
    }
}
