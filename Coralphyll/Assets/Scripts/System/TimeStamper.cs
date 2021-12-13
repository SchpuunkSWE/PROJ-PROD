using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TimeStamper : MonoBehaviour
{
    #region Singleton Quickversion
    public static TimeStamper TimeStamperInstance;

    private void Awake()
    {
        TimeStamperInstance = this;
    }

    #endregion

    private void Start()
    {
        Directory.CreateDirectory(Application.streamingAssetsPath + "/Chat Logs/"); //Creates the folder
    }

    public void WriteToTxtFile(string description)
    {
        string txtDocumentName = Application.streamingAssetsPath + "/Chat_Logs/" + "Chat" + ".txt"; //Creates the text file in the directory in start

        if (!File.Exists(txtDocumentName))
        {
            File.WriteAllText(txtDocumentName, "TIMESTAMPS: \n \n"); //Creates a header for the txt file 
        }

        File.AppendAllText(txtDocumentName, description + DateTime.Now);

        //string path = Application.persistentDataPath + ".txt";
        ////Write some text to the .txt file
        //StreamWriter writer = new StreamWriter(path, true);
        //writer.WriteLine(description + DateTime.Now);
        //writer.Close();
        //StreamReader reader = new StreamReader(path);
        ////Print the text from the file
        //Debug.Log(reader.ReadToEnd());
        //reader.Close();
    }
}
