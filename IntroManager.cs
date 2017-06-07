using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour {

    public GameObject startText;
    private float _timer;
    private bool _loadingLevel;
    private bool _init;

    public int activeElement;
    public GameObject menuObj;

    public ButtonRef[] menuOpts;

    void Start() { menuObj.SetActive(false); }

    void Update() {
        if (!_init) {
            _timer += Time.deltaTime;
            if (_timer > .5f) {
                _timer = 0;
                startText.SetActive(!startText.activeInHierarchy);
            }
            if (Input.GetKeyUp(KeyCode.Space) || Input.GetButtonUp("Jump")) {
                _init = true;
                startText.SetActive(true);
                menuObj.SetActive(true);
            }
        } else {
            if (!_loadingLevel) {
                menuOpts[activeElement].selected = true;
                if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W)) {
                    menuOpts[activeElement].selected = false;
                    if (activeElement > 0) {
                        activeElement--;
                    } else {
                        activeElement = menuOpts.Length - 1;
                    }
                }
                if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)) {
                    menuOpts[activeElement].selected = false;
                    if (activeElement < menuOpts.Length - 1) {
                        activeElement++;
                    } else {
                        activeElement = 0;
                    }
                }
                if (Input.GetKeyUp(KeyCode.Space) || Input.GetButtonUp("Jump")) {
                    Debug.Log("Load Level");
                    _loadingLevel = true;
                    StartCoroutine("LoadLevel");
                    menuOpts[activeElement].transform.localScale *= 1.2f;
                }
            }
        }
    }

    private void HandleSelectedOption() {
        switch (activeElement) {
            case 0:
                CharacterManager.GetInstance().playersNumber = 1;
                break;
            case 1:
                CharacterManager.GetInstance().playersNumber = 2;
                CharacterManager.GetInstance().players[1].playerType = PlayerBase.PlayerType.User;
                break;
        }
    }

    IEnumerator LoadLevel() {
        HandleSelectedOption();
        yield return new WaitForSeconds(.6f);

        startText.SetActive(false);
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadSceneAsync("CharacterSelection", LoadSceneMode.Single);
    }

}