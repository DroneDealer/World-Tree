using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeIn : MonoBehaviour
{
    public Image fadeImage;
    private void SetAlpha(float alpha)
    {
        Color hex = fadeImage.color;
        hex.a = alpha;
        fadeImage.color = hex;
    }
    void Awake()
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
        if (fadeImage == null)
        {
            fadeImage = GetComponent<Image>();
        }
        SetAlpha(0f);
        fadeImage.raycastTarget = false;

    }
    public IEnumerator fadeIn(float duration = 1f)
    {
        if (!fadeImage.gameObject.activeSelf)
        {
            fadeImage.gameObject.SetActive(true);
        }
        SetAlpha(0f);
        fadeImage.raycastTarget = true;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.unscaledDeltaTime;
            SetAlpha(Mathf.Lerp(0f, 1f, elapsed / duration));
            yield return null;
        }

        SetAlpha(1f);
    }
    public IEnumerator FadeOut(float duration = 1f)
    {
        if (!fadeImage.gameObject.activeSelf)
        fadeImage.gameObject.SetActive(true);
        SetAlpha(1f);
        fadeImage.raycastTarget = true;
        float elpased = 0f;
        while (elpased < duration)
        {
            elpased += Time.unscaledDeltaTime;
            SetAlpha(Mathf.Lerp(1f, 0f, elpased / duration));
            yield return null;
        }
        SetAlpha(0f);
        fadeImage.raycastTarget = false;
    }
}
