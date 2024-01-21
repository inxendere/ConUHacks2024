using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FirstPrompt : MonoBehaviour
{
    public ChatGPTManager chatGPTManager;
    bool hasRun = false;

    string[] Queries = new string[5];
    string[] dishNames = new string[5];
    string[] dishTime = new string[5];
    string[] dishDifficulty = new string[5];

    public List<GameObject> dishButtons = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {

        //if (chatGPTManager.counter != 1 ) return;

        if (!hasRun && chatGPTManager.counter == 1 && chatGPTManager.gptResponse != "")
        {
            //Debug.Log("isrybbg");
            FirstPromptFUNC();
        }

        // if (Queries.Length > 0)
        // {
        //     foreach (string query in Queries)
        //     {
        //         Debug.Log(query);
        //     }
        // }

    }

    public void FirstPromptFUNC()
    {
        hasRun = true;
        string[] Lines = chatGPTManager.gptResponse.Split("\n");

        int i = 0;

        while (i < 5)
        {
            string[] CommaSplits = Lines[i].Split(",");
            // Debug.Log(CommaSplits[0]);
            // Debug.Log(CommaSplits[1]);
            // Debug.Log(CommaSplits[2]);

            Queries[i] = CommaSplits[0];
            dishNames[i] = CommaSplits[0];
            dishTime[i] = CommaSplits[1];
            dishDifficulty[i] = CommaSplits[2];

            i++;
        }

        FillDishButtons();
    }

    public void FillDishButtons()
    {
        int i = 0;
        foreach (GameObject dishButton in dishButtons)
        {
            dishButton.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = " " + dishNames[i];
            dishButton.transform.Find("TimeToCook").GetComponent<TextMeshProUGUI>().text = dishTime[i];
            dishButton.transform.Find("Difficulty").GetComponent<TextMeshProUGUI>().text = " Difficulty:" + dishDifficulty[i];
            i++;
        }
    }

}
