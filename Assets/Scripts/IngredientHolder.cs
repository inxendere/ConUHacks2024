using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientHolder : MonoBehaviour
{
    public List<string> selectedIngredients;
    public ChatGPTManager chatGPTManager;
    public string selectedIngredientsString = "";

    private void Awake()
    {
        selectedIngredientsString = "";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // delete all buttons
            GameObject[] buttons = GameObject.FindGameObjectsWithTag("IngredientButtonTAG");

            foreach (GameObject button in buttons)
            {
                Destroy(button);
            }


            foreach (string ingredient in selectedIngredients)
            {
                selectedIngredientsString += ingredient + ",";
            }

            chatGPTManager.AskChatGPT(selectedIngredientsString);
        }
    }

}
