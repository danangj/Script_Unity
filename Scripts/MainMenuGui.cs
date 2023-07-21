using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuGui : MonoBehaviour {
    [SerializeField]
    Texture2D _mainMenuBg;

    [SerializeField]
    Texture2D _title;

    [SerializeField]
    Texture2D _newGameButton;

    [SerializeField]
    Texture2D _optionsButton;

    [SerializeField]
    Texture2D _quitButton;

    [SerializeField]
    GUISkin _guiSkin;

    void OnGUI(){
        GUI.skin = _guiSkin;
        
        GUI.DrawTexture (new Rect(0,0, Screen.width, Screen.height), _mainMenuBg);
        GUI.DrawTexture (new Rect(Screen.width - _title.width - 20, 20, _title.width, _title.height), _title);
        if (GUI.Button (new Rect (20, 150, 270, _newGameButton.height), _newGameButton)) {
            
        }
        if (GUI.Button (new Rect (20, 150 + 88 + 10, 270, _optionsButton.height), _optionsButton)) {

        }

        if (GUI.Button (new Rect (20, 150 + (2 * (88 + 10)), 270, _quitButton.height), _quitButton)) {
            Application.Quit ();
        }
    }
}
