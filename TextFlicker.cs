using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFlicker : MonoBehaviour {

    public float _timer;
    public float _flickerFreq;
    public GameObject[] _flickableGameObjects;

    void Update() { Flick(_flickerFreq, _flickableGameObjects); }

    private void Flick(float flickFrequency, GameObject[] flickTargetTexts) {
        _timer += Time.deltaTime;
        if (_timer > flickFrequency) {
            _timer = 0;
            foreach (GameObject flickerable in flickTargetTexts) {
                flickerable.SetActive(!flickerable.activeInHierarchy);
            }
        }
    }

}