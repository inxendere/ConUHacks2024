using UnityEngine;

public class EnableGameObjectOnClick : MonoBehaviour
{
    public GameObject objectToEnable; // Assign this in the inspecto

    public Animator searchBoxAnim;

    public void enableObject()
    {
        objectToEnable.SetActive(true);


        searchBoxAnim.SetBool("hasClicked", true);

    }


}
