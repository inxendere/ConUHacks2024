using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPrompt : MonoBehaviour
{
    public ChatGPTManager chatGPTManager;
    bool hasRun = false;

    string[] Queries = new string[5];

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //if (chatGPTManager.counter != 1 ) return;

        if (!hasRun && chatGPTManager.counter == 1 && chatGPTManager.gptResponse != "")
        {
            //Debug.Log("isrybbg");
            FirstPromptFUNC();
        }

/*        if(Queries.Length > 0)
        {
            foreach (string query in Queries) {
                Debug.Log(query);}
        }*/

    }

    public void FirstPromptFUNC()
    {
        hasRun = true;
        string[] Lines = chatGPTManager.gptResponse.Split("\n");

        int i = 0;
        
        while (i < 5)
        {
            string[] CommaSplits = Lines[i].Split(",");
            Queries[i] = CommaSplits[0];
            i++;
        }
    }

}
