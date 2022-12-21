using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;

public class ScriptReader : MonoBehaviour
{
    [SerializeField]
    private TextAsset _InkJsonFile;
    private Story _StoryScript;

    public TMP_Text dialogueBox;
    public TMP_Text nameTag;

    public GameObject MainCharImg;
    public GameObject OtherCharImg;

    private const string _MCName = "Gordon"; // The name of the main character

    void Start()
    {
       LoadStory();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            DisplayNextLine();
        }
    }

    void LoadStory()
    {
        _StoryScript = new Story(_InkJsonFile.text);
        _StoryScript.BindExternalFunction("Name",(string charName) => {
            ChangeName(charName);
            ColorCharImages(charName);
        });
    }

    public void DisplayNextLine()
    {
        if(_StoryScript.canContinue) // Checks if there is content to go through
        { 
            string text = _StoryScript.Continue();  // Gets next line
            text = text?.Trim(); // Removes white space
            dialogueBox.text = text; // Displays news text
        }
        else {
            dialogueBox.text = "Out of text!!!";
        }
    }

    public void ChangeName(string name)
    {
        string SpeakerName = name;
        nameTag.text = SpeakerName;
    }

    private Color32 gray = new Color32(64, 64, 64, 225);
    private Color32 none = new Color32(225, 225, 225, 225);

    public void ColorCharImages(string n) /// Gives the image of the non-speaker character a gray tint
    {
        //Reset Image Color
        ChangeColor(MainCharImg,none);
        ChangeColor(OtherCharImg,none);

        // If MC is talking, make other guy gray
        if (n == _MCName) {
            ChangeColor(OtherCharImg,gray);
        }

        // IF MC is not talking, make MC gray
        else {
            ChangeColor(MainCharImg,gray);
        }
    }

    public void ChangeColor(GameObject go, Color32 c) {
        go.GetComponent<Image>().color = c;
    }
}