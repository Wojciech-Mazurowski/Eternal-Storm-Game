using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        List<long> linesNum= new List<long>();
        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File not found");
            return;
        }
        string[] lines = System.IO.File.ReadAllLines(destination);
        foreach (string line in lines)
        {
            linesNum.Add(Int64.Parse(line));
        }

        var xd = linesNum.OrderByDescending(i => i).ToList();

        var mid = Math.Min(textMeshProUGUIs.Count, linesNum.Count);
        for(int i= 0; i<mid; i++)
        {
            Debug.Log(mid);
            textMeshProUGUIs[i].enabled = true;
            textMeshProUGUIs[i].text = xd[i].ToString();
        }
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
