using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenAI;
using TMPro;

public class ChatGPTManager : MonoBehaviour
{
    /// <summary>
    /// Note: you have to put your own ChatGPT api in the user folder
    /// In your user folder in C drive, create a folder and call it .openai
    /// In that folder, create a json called auth.json
    /// In there, fill in the following:
    /// {
    ///  "api_key": "YOUR API KEY HERE",
    ///  "organization": "YOUR ORGANIZATION HERE"
    /// }
    /// </summary>
    /// 
    private OpenAIApi openAI = new OpenAIApi();
    private List<ChatMessage> messages = new List<ChatMessage>();

    public string gptResponse;

    public int counter = 0;

    [Header("Ui stuff")]
    public GameObject dishPanel;
    public TextMeshProUGUI responseText;
    public GameObject dishButtonsParent;
    public GameObject loadingScreen;


    private void Awake()
    {
        dishPanel.SetActive(false);
        responseText.text = "Waiting for your input...";
        counter = 0;
        dishButtonsParent.SetActive(false);
    }

    public async void AskChatGPT(string newText)
    {
        counter += 1;
        dishPanel.SetActive(true);
        responseText.text = "Looking for dishes...";

        ChatMessage newMessage = new ChatMessage();
        newMessage.Content = "Give me a list of 5 dishes that use these ingredients (you don't have to use all the ingredients) with their cooking times and difficulty from easy, medium, hard in this format per line without any extra words or introduction: dish name, cooking time, difficulty." + newText;
        newMessage.Role = "user";

        messages.Add(newMessage);

        CreateChatCompletionRequest request = new CreateChatCompletionRequest();
        request.Messages = messages;
        // request.Model = "text-embedding-ada-002";
        request.Model = "gpt-4-1106-preview";

        StartCoroutine(StartLoadingAnimation());

        var response = await openAI.CreateChatCompletion(request);

        if (response.Choices != null && response.Choices.Count > 0)
        {
            // StopCoroutine(StartLoadingAnimation());
            StopAllCoroutines();
            loadingScreen.SetActive(false);
            dishButtonsParent.SetActive(true);

            var chatResponse = response.Choices[0].Message;

            messages.Add(chatResponse);

            // Debug.Log(chatResponse.Content);

            responseText.text = chatResponse.Content;
            gptResponse = chatResponse.Content;

            // activate dishesbutton

        }
    }

    IEnumerator StartLoadingAnimation()
    {
        loadingScreen.SetActive(true);

        TextMeshProUGUI loadingText = loadingScreen.GetComponentInChildren<TextMeshProUGUI>();
        // for now
        responseText.text = "Looking for dishes...";
        loadingText.text = "Looking for dishes...";
        yield return new WaitForSeconds(1f);
        responseText.text = "Looking for dishes....";
        loadingText.text = "Looking for dishes....";

        yield return new WaitForSeconds(1f);
        responseText.text = "Looking for dishes.....";
        loadingText.text = "Looking for dishes....";

        yield return new WaitForSeconds(1f);
        StartCoroutine(StartLoadingAnimation());
    }
}
