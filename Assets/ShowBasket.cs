using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBasket : MonoBehaviour
{
    public Animator basketAnimator;

    public void BringDownBasket()
    {
        basketAnimator.SetBool("clickedOnSearch", true);
    }

}
