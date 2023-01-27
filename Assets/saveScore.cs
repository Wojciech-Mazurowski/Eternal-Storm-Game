using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class saveScore : MonoBehaviour
{
    public async void SaveFile()
    {
        string destination = Application.persistentDataPath + "/save.txt";
        Debug.Log(Application.persistentDataPath);
        using StreamWriter file = new(destination, append: true);
        await file.WriteLineAsync(scoreManager.scoreText.text);
    }
    // Start is called before the first frame update
    void Start()
    {
        SaveFile();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
