using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDamageCollider : StateMachineBehaviour {

    private StateManager _states;

    public HandleDamageColliders.DamageType damageType;
    public HandleDamageColliders.DcType dcType;

    public float delay;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (_states == null) {
            _states = animator.transform.GetComponentInParent<StateManager>();

            _states.handleDC.OpenCollider(dcType, delay, damageType);
        } else {
            _states.handleDC.OpenCollider(dcType, delay, damageType);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (_states == null) {
            _states = animator.transform.GetComponentInParent<StateManager>();

            _states.handleDC.CloseColliders();
        } else {
            _states.handleDC.CloseColliders();
        }
    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

}