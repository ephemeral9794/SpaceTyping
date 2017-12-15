using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextObject : MonoBehaviour
{
    public Text stringText;
    public Text alphabetText;
    public Dictionary dictionary;
    public GameManager manager;

    private TypingSystem ts;

    void Start() {
        ts = new TypingSystem();
        //ts.SetInputString("どんこうれっしゃ");
        ts.SetInputString(dictionary.GetRandomWord());
        UpdateText();
	}
	
	void Update() {
        string[] keys = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "-", };
        foreach (string key in keys)
        {
            if (Input.GetKeyDown(key))
            {
                if (ts.InputKey(key) == 1)
                {
                    UpdateText();
                }
                break;
            }
        }
        if (ts.isEnded())
        {
            manager.CorrectQuestion();
            if (!manager.getClearFlag())
            {
                ts.SetInputString(dictionary.GetRandomWord());
                UpdateText();
            } else
            {
                ClearText();
                transform.FindChild("Window").gameObject.SetActive(false);
            }
        }
    }

    void UpdateText()
    {
        stringText.text = "<color=red>" + ts.GetInputedString() + "</color>" + ts.GetRestString();
        alphabetText.text = "<color=red>" + ts.GetInputedKey() + "</color>" + ts.GetRestKey();
    }

    void ClearText()
    {
        stringText.text = "";
        alphabetText.text = "";
    }
}
