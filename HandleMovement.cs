using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleMovement : MonoBehaviour {

    private Rigidbody2D _rb2d;
    private StateManager _states;
    private HandleAnimations _anim;

    public float acceleration = 15;
    public float airAcceleration = 6;
    public float maxSpeed = 60;
    public float jumpSpeed = 5;
    public float jumpDuration = 5;

    private float _actualSpeed;
    private bool _justJumped;
    private bool _canVariableJump;
    private float _jumpTimer;

    void Start() {
        _rb2d = GetComponent<Rigidbody2D>();
        _states = GetComponent<StateManager>();
        _anim = GetComponent<HandleAnimations>();
        _rb2d.freezeRotation = true;
    }

    void Update() {
        if (!_states.dontMove) {
            HorizontalMovement();
            Jump();
        }
    }

    private void HorizontalMovement() {
        _actualSpeed = this.maxSpeed;

        if (_states.onGround && !_states.currentlyAttacking) {
            _rb2d.AddForce(new Vector2((_states.horizontal * _actualSpeed) - _rb2d.velocity.x * this.acceleration, 0));
        }
    }

    private void Jump() { }

}