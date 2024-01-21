using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class FlashingEllipsis : MonoBehaviour
{
    public TextMeshProUGUI titleText; // Assign this in the inspector
    private string baseTitle = "Don't know what to make? Tell me what you have"; // Replace with your actual title

    void Start()
    {
        if (titleText == null)
        {
            Debug.LogError("TitleText is not assigned!");
            return;
        }
        StartCoroutine(FlashingRoutine());
    }

    IEnumerator FlashingRoutine()
    {
        while (true)
        {
            titleText.text = baseTitle + ".";
            yield return new WaitForSeconds(0.2f); // Interval for each dot

            titleText.text = baseTitle + "..";
            yield return new WaitForSeconds(0.2f); // Interval for each dot

            titleText.text = baseTitle + "...";
            yield return new WaitForSeconds(0.2f); // Interval for each dot

            float randomInterval = Random.Range(1f, 2f); // Random interval between 1 and 10 seconds
            titleText.text = baseTitle; // Remove the dots during the wait
            yield return new WaitForSeconds(randomInterval); // Wait for a random interval before starting over
        }
    }
}
