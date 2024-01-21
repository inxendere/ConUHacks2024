using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateOtherUI_1 : MonoBehaviour
{
    public List<GameObject> objectsToDisable = new List<GameObject>();
    // Start is called before the first frame update
    private void OnEnable()
    {
        foreach (GameObject gObject in objectsToDisable)
        {
            gObject.SetActive(false);
        }
    }
}
