using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : StateMachineBehaviour
{
    // Cuando se sale del estado de muerte en el animator, se llama a la función EndGame del Game Manager
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FindObjectOfType<GameManager>().EndGame(); 
    }
}
