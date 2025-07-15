using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
// This line is very useful - it won't let you attach this script to a GameObject without a spriterenderer
public class BgRescale : MonoBehaviour
{
    void Start()
    {
        float ScreenHeight = Camera.main.orthographicSize * 2;
        float ScreenWidth = ScreenHeight * Screen.width / Screen.height;

        SpriteRenderer background = GetComponent<SpriteRenderer>();
        if (background == null || background.sprite == null)
        {
            Debug.Log("More stuff is mssing. You cannot catch a break!");
            return;
        }
        Vector2 spriteSize = background.sprite.bounds.size;
        Vector3 newScale = transform.localScale;

        newScale.x = ScreenWidth / spriteSize.x;
        newScale.y = ScreenHeight / spriteSize.y;

        transform.localScale = newScale;
    }    
}
