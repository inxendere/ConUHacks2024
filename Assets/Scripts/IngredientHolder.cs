using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IngredientHolder : MonoBehaviour
{
    public List<string> selectedIngredients;
    public ChatGPTManager chatGPTManager;

    public string ingredientBasket = "Ingredients you have:";    // for the user to see
    public string selectedIngredientsString = "";   // for the ai

    public TextMeshProUGUI ingredientBasketTMPro;

    public int numberOfSelIngredients = 0;
    int numberOfSelIngredientsCheck = 0;


    private void Awake()
    {
        selectedIngredientsString = "";
        ingredientBasket = "Ingredients you have: \n";
    }

    private void Update()
    {

        if (numberOfSelIngredientsCheck != numberOfSelIngredients)
        {
            numberOfSelIngredientsCheck = numberOfSelIngredients;
            ingredientBasket = "Ingredients you have: \n";

            foreach (string ingredient in selectedIngredients)
            {
                ingredientBasket += "-" + ingredient + "\n";
            }

            ingredientBasketTMPro.text = ingredientBasket;

        }

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

    public void UpdateIngredientBasket()
    {

    }

}
