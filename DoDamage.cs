using UnityEngine;
using System.Collections;

public class DoDamage : MonoBehaviour {

    private StateManager _states;
    public HandleDamageColliders.DamageType damageType;

    void Start() { _states = GetComponentInParent<StateManager>(); }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponentInParent<StateManager>()) {
            StateManager otherState = other.GetComponentInParent<StateManager>();

            if (otherState != _states) {
                if (!otherState.currentlyAttacking) {
                    print("Do some damage!");
                    //TODO: otherState.TakeDamage(30, damageType);
                }
            }
        }
    }

}