using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {

    public int playersNumber;
    public List<PlayerBase> players = new List<PlayerBase>(); // list of players and their types

    public List<CharacterBase> characterList = new List<CharacterBase>();

    public CharacterBase ReturnCharacterWithId(string id) {
        CharacterBase retVal = null;

        for (int i = 0; i < characterList.Count; i++) {
            if (string.Equals(characterList[i].charId, id)) {
                retVal = characterList[i];
            }
        }

        return retVal;
    }

    public PlayerBase ReturnPlayerFromStates(StateManager states) {
        PlayerBase retVal = null;

        for (int i = 0; i < players.Count; i++) {
            if (players[i].playerStates == states) {
                retVal = players[i];
                break;
            }
        }

        return retVal;
    }

    public static CharacterManager instance; // static for not creating object everytime i want to access this
    public static CharacterManager GetInstance() { return instance; }

    void Awake() {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Start() { }

    void Update() { }

}

[System.Serializable]
public class PlayerBase {

    public string playerId;
    public string inputId;
    public PlayerType playerType;
    public bool hasCharacter;
    public GameObject playerPrefab;
    public StateManager playerStates;
    public int score;

    public enum PlayerType {

        User,
        Ai,
        Sim,

    }

}

[System.Serializable]
public class CharacterBase {

    public string charId;
    public GameObject prefab;

}