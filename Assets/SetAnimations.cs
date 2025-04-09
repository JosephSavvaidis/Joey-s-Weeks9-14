using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimations : MonoBehaviour
{
    public Animator anim;
    public void changeBackToIdle()
    {
       anim.SetInteger("State", 0);
    }
}
