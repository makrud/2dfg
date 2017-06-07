using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersTypeLabels : MonoBehaviour {

    public GameObject Player1;
    public GameObject Player2;
    public GameObject CPU;

    void Awake() {
        Player1.SetActive(true);

        switch (CharacterManager.GetInstance().playersNumber) {
            case 1: {
                CPU.SetActive(true);
                break;
            }
            case 2: {
                Player2.SetActive(true);
                break;
            }
        }
    }

}