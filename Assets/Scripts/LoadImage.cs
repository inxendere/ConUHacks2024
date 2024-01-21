using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using TMPro;

public class UnsplashImageLoader : MonoBehaviour
{
    public string unsplashAccessKey = "BwbNg-WF1SFol3XfoxgouXakGG9QeVl5vOtkFbJiBS0";
    public TextMeshProUGUI searchInput;
    public RawImage rawImage;


    [Serializable]
    private class UnsplashResponse
    {
        public List<UnsplashResult> results;
    }

    [Serializable]
    private class UnsplashResult
    {
        public UnsplashUrls urls;
    }

    [Serializable]
    private class UnsplashUrls
    {
        public string regular;
    }

    private void Start()
    {
        // Attach the method to the OnEndEdit event of the input field
        //searchInput.onEndEdit.AddListener(OnSearchInputEndEdit);
    }
    private void OnEnable()
    {
        Invoke("SearchAndDisplayImage", 0.1f);
    }

    private void OnSearchInputEndEdit(string text)
    {
        // Check if the Enter key was pressed
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            SearchAndDisplayImage();
        }
    }

    public void SearchAndDisplayImage()
    {
        string query = searchInput.text;
        Debug.Log(searchInput.text);
        StartCoroutine(LoadImage(query));
    }

    public IEnumerator<object> LoadImage(String query)
    {
        string requestUrl = $"https://api.unsplash.com/search/photos?query={query}&client_id={unsplashAccessKey}&per_page=1";

        using (UnityWebRequest webRequest = UnityWebRequest.Get(requestUrl))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError($"Error: {webRequest.error}");
            }
            else
            {
                // Parse the JSON response to extract the first image URL
                string jsonResponse = webRequest.downloadHandler.text;
                string imageUrl = ParseFirstImageUrl(jsonResponse);

                // Load the image onto the RawImage component
                StartCoroutine(LoadImageCoroutine(imageUrl));
            }
        }
    }

    IEnumerator<object> LoadImageCoroutine(string imageUrl)
    {
        using (UnityWebRequest imageRequest = UnityWebRequestTexture.GetTexture(imageUrl))
        {
            yield return imageRequest.SendWebRequest();

            if (imageRequest.result == UnityWebRequest.Result.ConnectionError || imageRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError($"Error loading image: {imageRequest.error}");
            }
            else
            {
                // Set the downloaded texture to the RawImage component
                Texture2D texture = DownloadHandlerTexture.GetContent(imageRequest);
                rawImage.texture = texture;
            }
        }
    }

    // Use JsonUtility to parse the JSON response
    private string ParseFirstImageUrl(string jsonResponse)
    {
        try
        {
            UnsplashResponse response = JsonUtility.FromJson<UnsplashResponse>(jsonResponse);

            if (response.results != null && response.results.Count > 0)
            {
                UnsplashResult firstResult = response.results[0];

                if (firstResult.urls != null && !string.IsNullOrEmpty(firstResult.urls.regular))
                {
                    return firstResult.urls.regular;
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Error parsing JSON: {e.Message}");
        }

        return null;
    }
}
