using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

    public string playerInput;

    private float _horizontal;
    private float _vertical;
    private bool _attackA;
    private bool _attackB;
    private bool _attackC;
    private bool _attackD;
    private bool _kick;

    private StateManager _states;

    void Start() { _states = GetComponent<StateManager>(); }

    void FixedUpdate() {
        _horizontal = Input.GetAxis("Horizontal" + playerInput);
        _vertical = Input.GetAxis("Vertical" + playerInput);
        _attackA = Input.GetButton("AttackA" + playerInput);
        _attackB = Input.GetButton("AttackB" + playerInput);
        _attackC = Input.GetButton("AttackC" + playerInput);
        _attackD = Input.GetButton("AttackD" + playerInput);
        _kick = Input.GetButton("Kick" + playerInput);

        _states.horizontal = _horizontal;
        _states.vertical = _vertical;
        _states.attackA = _attackA;
        _states.attackB = _attackB;
        _states.attackC = _attackC;
        _states.attackD = _attackD;
        _states.kick = _kick;
    }

}