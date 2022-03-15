using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WriteFile : MonoBehaviour
{
    public List<Vector3> positions;
    public string testFile;
    public int stopFrame;

    void Start(){
        positions = new List<Vector3>();
        testFile = Application.dataPath + "/testfile.csv";
    }

    void Update()
    {
        
        positions.Add(transform.position);

        if (Time.frameCount == stopFrame){
            WriteListToFile();
        }
    }

    void WriteListToFile(){
        if (File.Exists(testFile))
        {
            Debug.Log(testFile+" already exists.");
            return;
        }
        
        var sr = File.CreateText(testFile);
        foreach (Vector3 position in positions)
        sr.WriteLine (position.x + "," + position.y);
        sr.Close();
    }
}
