using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideDishInfo : MonoBehaviour
{
    public GameObject dishInfo;

    public void HideDishInfoFUNC()
    {
        dishInfo.SetActive(false);
    }

}
