using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameScript : MonoBehaviour
{
    public Transform object1;  // Reference to the first object
    public Transform object2;  // Reference to the second object
    public Transform object3;  // Reference to the third object
    public Image fadeImage;
    public float rotationDuration = 5f;  // The duration of the rotation (in seconds)
    public float fadeDuration = 10f;  // Duration of the fade effect
    private void Start()
    {
        // Start the game with a fade from black
        StartCoroutine(FadeFromBlack());
    }
    public void PlayGame()
    {
        // Start the rotation coroutine for all objects
        StartCoroutine(RotateOverTime(object1));
        StartCoroutine(RotateOverTime(object2));
        StartCoroutine(RotateOverTime(object3));
        StartCoroutine(LoadSceneAfterPause());
    }
    IEnumerator FadeFromBlack()
    {
        Color fadeColor = fadeImage.color;
        for (float t = fadeDuration; t >= 0; t -= Time.deltaTime)
        {
            fadeColor.a = t / fadeDuration;
            fadeImage.color = fadeColor;
            yield return null;
        }

        fadeImage.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, 0);
    }

    IEnumerator RotateOverTime(Transform obj)
    {
        float elapsedTime = 0f;  // Track the elapsed time
        Quaternion startRotation = obj.rotation;  // Initial rotation
        Quaternion endRotation = Quaternion.Euler(0, 90, 0);  // Target rotation (0, 90, 0)

        while (elapsedTime < rotationDuration)
        {
            // Rotate the object from the starting rotation to the target rotation over time
            obj.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / rotationDuration);

            elapsedTime += Time.deltaTime;  // Update the elapsed time
            yield return null;  // Wait for the next frame
        }

        // Ensure the final rotation is exactly 90 degrees on the Y-axis
        obj.rotation = endRotation;
    }
    IEnumerator LoadSceneAfterPause()
    {
        yield return new WaitForSeconds(rotationDuration - fadeDuration);
        Color fadeColor = fadeImage.color;
        for (float t = 0; t <= fadeDuration; t += Time.deltaTime)
        {
            fadeColor.a = t / fadeDuration;
            fadeImage.color = fadeColor;
            yield return null;
        }

        fadeImage.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, 1);
        SceneManager.LoadSceneAsync("GradScene");
    }
}
