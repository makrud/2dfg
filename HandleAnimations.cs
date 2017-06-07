using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleAnimations : MonoBehaviour {

    public Animator anim;
    private StateManager _states;

    public float attackRate = .3f;
    public AttackBase[] attacks = new AttackBase[2];

    private void Start() {
        _states = GetComponent<StateManager>();
        anim = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate() {
        _states.dontMove = anim.GetBool("DontMove");

        anim.SetBool("TakesHit", _states.gettingHit);

        //TODO: go back when jump will be touched
        
        //anim.SetBool("OnAir", !_states.onGround);

        //anim.SetBool("Crouch", _states.crouch);

        float movement = Mathf.Abs(_states.horizontal);
        if (movement > 0) {
            anim.SetFloat("Movement", movement);
        } else {
            anim.SetFloat("Movement", movement);
        }

        if (_states.vertical < 0) {
            _states.crouch = true;
        } else {
            _states.crouch = false;
        }

        HandleAttack(_states.attackA, _states.indexA, "AttackA");
        HandleAttack(_states.attackB, _states.indexB, "AttackB");
        HandleAttack(_states.attackC, _states.indexC, "AttackC");
        HandleAttack(_states.attackD, _states.indexD, "AttackD");
        HandleAttack(_states.kick, _states.indexKick, "Kick");
    }

    private void HandleAttack(bool performAttack, int attackIndex, string animBool) {
        if (_states.canAttack) {
            if (performAttack) {
                _states.currentlyAttacking = true;
                attacks[attackIndex].attack = true;
                attacks[attackIndex].attackTimer = 0;
                attacks[attackIndex].timesPressed++;
            }
            if (attacks[attackIndex].attack) {
                attacks[attackIndex].attackTimer += Time.deltaTime;

                if (attacks[attackIndex].attackTimer > attackRate || attacks[attackIndex].timesPressed >= 3) {
                    attacks[attackIndex].attack = false;
                    attacks[attackIndex].attackTimer = 0;
                    attacks[attackIndex].timesPressed = 0;
                }
            }
        }
        anim.SetBool(animBool, attacks[attackIndex].attack);
        _states.currentlyAttacking = false;
    }


    [System.Serializable]
    public class AttackBase {

        public bool attack;
        public float attackTimer;
        public int timesPressed;

    }

}