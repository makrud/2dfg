using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleDamageColliders : MonoBehaviour {

    public GameObject[] damageCollidersLeft;
    public GameObject[] damageCollidersRight;

    private StateManager _states;

    public enum DamageType {

        Light,
        Heavy

    }

    public enum DcType {

        Up,
        Down

    }

    private void Start() {
        _states = GetComponent<StateManager>();
        CloseColliders();
    }

    public void CloseColliders() {
        for (int i = 0; i < damageCollidersLeft.Length; i++) {
            damageCollidersLeft[i].SetActive(false);
            damageCollidersRight[i].SetActive(false);
        }
    }

    public void OpenCollider(DcType damageColliderType, float delay, DamageType damageType) {
        if (!_states.lookingRight) {
            switch (damageColliderType) {
                case DcType.Down:
                    StartCoroutine(OpenCollider(damageCollidersLeft, 0, delay, damageType));
                    break;
                case DcType.Up:
                    StartCoroutine(OpenCollider(damageCollidersLeft, 1, delay, damageType));
                    break;
            }
        } else {
            switch (damageColliderType) {
                case DcType.Down:
                    StartCoroutine(OpenCollider(damageCollidersRight, 0, delay, damageType));
                    break;
                case DcType.Up:
                    StartCoroutine(OpenCollider(damageCollidersRight, 1, delay, damageType));
                    break;
            }
        }
    }

    private IEnumerator OpenCollider(GameObject[] array, int index, float delay, DamageType damageType) {
        yield return new WaitForSeconds(delay);

        array[index].SetActive(true);
        array[index].GetComponent<DoDamage>().damageType = damageType;
    }

}