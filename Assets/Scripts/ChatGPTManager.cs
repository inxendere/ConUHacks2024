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

    private OpenAIApi openAI = new OpenAIApi();
    private List<ChatMessage> messages = new List<ChatMessage>();
    public TextMeshProUGUI responseText;

    private void Awake()
    {
        responseText.text = "Waiting for your input...";
    }

    public async void AskChatGPT(string newText)
    {
        responseText.text = "Looking for ingredients...";

        ChatMessage newMessage = new ChatMessage();
        newMessage.Content = newText;
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
            var chatResponse = response.Choices[0].Message;

            messages.Add(chatResponse);

            Debug.Log(chatResponse.Content);

            responseText.text = chatResponse.Content;
        }
    }

    IEnumerator StartLoadingAnimation()
    {
        responseText.text = "Looking for ingredients...";
        yield return new WaitForSeconds(1f);
        responseText.text = "Looking for ingredients....";
        yield return new WaitForSeconds(1f);
        responseText.text = "Looking for ingredients.....";
        yield return new WaitForSeconds(1f);
        StartCoroutine(StartLoadingAnimation());
    }
}
