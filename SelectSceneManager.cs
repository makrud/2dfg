using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectSceneManager : MonoBehaviour {

    public int numberOfPlayers = 1;

    public PortraitInfo[] portraitPrefabs;
    public List<PlayerInterfaces> playerInterfaces = new List<PlayerInterfaces>();

    public int maxX;
    public int maxY;

    private PortraitInfo[,] _charGrid;
    public GameObject portraitCanvas;

    private bool _loadLevel;
    public bool selectedBothPlayers;

    private CharacterManager characterManager;

    void Awake() { }

    void Start() {
        characterManager = CharacterManager.GetInstance();
        numberOfPlayers = characterManager.playersNumber;

        _charGrid = new PortraitInfo[maxX, maxY];

        int x = 0;
        int y = 0;

        portraitPrefabs = portraitCanvas.GetComponentsInChildren<PortraitInfo>();

        for (int i = 0; i < portraitPrefabs.Length; i++) {
            portraitPrefabs[i].posX += x;
            portraitPrefabs[i].posY += y;

            _charGrid[x, y] = portraitPrefabs[i];

            if (x < maxX - 1) {
                x++;
            } else {
                x = 0;
                y++;
            }
        }
    }

    void Update() { }

    public class PlayerInterfaces {

        public PortraitInfo activePortrait; // current portrait for player 1
        public PortraitInfo previewPortrait;
        public GameObject selector; // indicator for p1

        public Transform charPos
            ; // character visualization after choosing, basically we choose character and it's prefab spawns on the scene

        public GameObject createdChar; // our created prefab for p1

        public int activeX;
        public int activeY;

        public bool hitInputOnce;
        public float timerToReset;

        public PlayerBase playerBase;

    }

}