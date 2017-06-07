using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour {

    public int health = 100;

    public float horizontal;
    public float vertical;

    public bool attackA;
    public int indexA = 0;

    public bool attackB;
    public int indexB = 1;

    public bool attackC;
    public int indexC = 2;

    public bool attackD;
    public int indexD = 3;

    public bool kick;
    public int indexKick = 4;

    public bool crouch;

    public bool canAttack;
    public bool gettingHit;
    public bool currentlyAttacking;

    public bool dontMove;
    public bool onGround;
    public bool lookingRight;

    private SpriteRenderer _sRenderer;
    [HideInInspector] public HandleDamageColliders handleDC;

    [HideInInspector] public HandleAnimations handleAnim;

    //[HideInInspector] public HandleMovement handleMovement;
    public GameObject[] movementColliders;

    private void Start() {
        handleDC = GetComponent<HandleDamageColliders>();
        _sRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update() { lookingRight = LookingRight(); }

    private void FixedUpdate() {
        if (!gettingHit && !currentlyAttacking) {
            canAttack = true;
        } else {
            canAttack = false;
        }
        onGround = OnGround();
    }

    public void CloseMovementCollider(int index) { movementColliders[index].SetActive(false); }

    public void OpenMovementCollider(int index) { movementColliders[index].SetActive(true); }

    private bool LookingRight() {
        bool flipSprite = _sRenderer.flipX ? horizontal > 0 : horizontal < 0;
        if (flipSprite) {
            _sRenderer.flipX = !_sRenderer.flipX;
        }
        return !_sRenderer.flipX ? lookingRight = true : lookingRight = false;
    }

    public void TakeDamage(int damageAmount, HandleDamageColliders.DamageType damageType) { }

    private bool OnGround() {
        bool retVal = false;

        LayerMask layer = ~(1 << LayerMask.NameToLayer("Ground"));
        retVal = Physics2D.Raycast(transform.position, -Vector2.up, .1f, layer);

        return retVal;
    }

    public void ResetStateInputs() {
        horizontal = 0;
        vertical = 0;
        attackA = false;
        attackB = false;
        attackC = false;
        attackD = false;
        kick = false;
        crouch = false;
        gettingHit = false;
        currentlyAttacking = false;
        dontMove = false;
    }

}