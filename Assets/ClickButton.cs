using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClickButton : MonoBehaviour
{
    public IngredientHolder ingredientHolder;
    public string buttonText;
    // Start is called before the first frame update
    void Start()
    {
        ingredientHolder = GameObject.FindGameObjectWithTag("SearchManager").GetComponent<IngredientHolder>();
        buttonText = gameObject.GetComponentInChildren<TextMeshProUGUI>().text.ToLower();
    }

    public void AddToIngredients()
    {
        if (ingredientHolder.selectedIngredients.Contains(buttonText))
        {
            ingredientHolder.selectedIngredients.Remove(buttonText);
        }
        else
        {
            ingredientHolder.selectedIngredients.Add(buttonText);
        }
    }
}
