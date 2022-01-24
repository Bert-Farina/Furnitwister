using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt : StateMachineBehaviour
{
    // Parar animación de Herida al salir del estado
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isHurt", false);
    }
}
