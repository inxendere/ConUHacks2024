using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DishButtonClick : MonoBehaviour
{
    public GameObject dishInfoPanel;
    public ChatGPTManager chatGPTManager;

    public TextMeshProUGUI nameOfDishObject;
    public string nameOfDish;

    private void Update()
    {
        nameOfDish = nameOfDishObject.text;

    }


    public void FindDishInformation()
    {
        chatGPTManager.GetCookingInstructions(nameOfDish);
    }

}
