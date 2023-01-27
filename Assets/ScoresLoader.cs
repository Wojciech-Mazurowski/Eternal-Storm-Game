using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;

public class ScoresLoader : MonoBehaviour
{

    public List<TextMeshProUGUI> textMeshProUGUIs;

    public void LoadFile()
    {
        string destination = Application.persistentDataPath + "/save.txt";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File not found");
            return;
        }

       
        //Debug.Log(data);
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadFile();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
