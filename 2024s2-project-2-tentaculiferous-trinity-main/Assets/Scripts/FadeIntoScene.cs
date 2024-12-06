using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeInScene : MonoBehaviour
{
    public Image fadeImage;  // UI Image to handle the fade effect (should be black and cover the whole screen)
    public float fadeDuration = 2f;  // Duration of the fade effect in seconds

    void Start()
    {
        // Start the fade-in effect
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        Color fadeColor = fadeImage.color;  // Get the current color of the image (assumed to be black with full alpha)
        fadeColor.a = 1f;  // Set the image to be fully opaque at the start

        float elapsedTime = 0f;

        // Gradually reduce the alpha over the fade duration
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            fadeColor.a = 1f - (elapsedTime / fadeDuration);  // Reduce alpha over time
            fadeImage.color = fadeColor;

            yield return null;  // Wait until the next frame
        }

        // Ensure the image is fully transparent at the end
        fadeColor.a = 0f;
        fadeImage.color = fadeColor;
    }
}