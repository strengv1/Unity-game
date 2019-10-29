using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomIdleBunny : StateMachineBehaviour
{
    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    Debug.Log("OnStateEnter");
    //}

    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    //  override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //  {
    //Debug.Log("OnStateUpdate");

    //  }

    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    //OnStateMove is called before OnStateMove is called on any state inside this state machine
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //Debug.Log("OnStateMove");
    //}

    // OnStateIK is called before OnStateIK is called on any state inside this state machine
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMachineEnter is called when entering a state machine via its Entry Node
    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        int rand = Random.Range(4, 13);
        if (rand < 5) {
            animator.SetInteger("idleAnimId", 0);
        } else if ( rand >= 7 && rand < 8) {
            animator.SetInteger("idleAnimId", 1);
        } else if (rand >= 8 && rand < 9) {
            animator.SetInteger("idleAnimId", 2);
        } else if (rand >= 9 && rand < 10) {
            animator.SetInteger("idleAnimId", 3);
        }
        else if (rand >= 10 && rand < 11)
        {
            animator.SetInteger("idleAnimId", 4);
        }
        else if (rand >= 11 && rand < 12)
        {
            animator.SetInteger("idleAnimId", 5);
        }
        else if (rand >= 12 && rand < 13)
        {
            animator.SetInteger("idleAnimId", 6);
        }

    }

    // OnStateMachineExit is called when exiting a state machine via its Exit Node
    //override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    //{
    //}
}
