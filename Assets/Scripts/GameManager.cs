using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

    public int QuestionNum = 0;
    public Text QNumText;
    public GameObject ClearText;

    private bool ClearFlag;

    private void Start()
    {
        ClearText.SetActive(false);
        ClearFlag = false;
    }

    // Update is called once per frame
    void Update () {
        QNumText.text = QuestionNum.ToString();
	}

    // 1問正解した
    public void CorrectQuestion()
    {
        if (QuestionNum > 0) {
            QuestionNum -= 1;
        }

        if (QuestionNum <= 0) {
            // クリア
            ClearText.SetActive(true);
            ClearFlag = true;
        }
    }

    public bool getClearFlag()
    {
        return ClearFlag;
    }
}
