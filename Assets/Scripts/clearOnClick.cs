using UnityEngine;
using UnityEngine.UI; // Include the UI namespace
using TMPro;

public class ClearInputField : MonoBehaviour
{
    public TMP_InputField searchInputField;

    void Start()
    {
        // Get the InputField component from the same GameObject this script is attached to
        //searchInputField = GetComponent<InputField>();
        // Add a listener that calls the ClearContent method when the input field is selected
        //searchInputField.OnSelect.AddListener((text) => { ClearContent(); });
    }

    public void ClearContent()
    {
        // Clear the content of the input field
        searchInputField.text = "";
    }
}