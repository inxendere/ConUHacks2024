using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishButtonClick : MonoBehaviour
{
    public GameObject dishInfoPanel;

    private void OnEnable()
    {
        dishInfoPanel = GameObject.FindGameObjectWithTag("DishInfoPanel");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
