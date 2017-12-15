using UnityEngine;
using System.Collections;

public class Dictionary : MonoBehaviour {
    public TextAsset resource;
    string[] words;

    void LoadDictionary()
    {
        string trimedData = resource.text.Replace("\r", "");
        char[] dem = { '\n' };
        words = trimedData.Split(dem);
    }

    void Awake()
    {
        LoadDictionary();
    }

    public string GetRandomWord()
    {
        return words[Random.Range(0, words.Length)];
    }
}
