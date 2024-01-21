using UnityEngine;

public class EnableGameObjectOnClick : MonoBehaviour
{
    public GameObject objectToEnable; // Assign this in the inspecto

    public void enableObject()
    {
        objectToEnable.SetActive(true);
    }
}
