using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Logger : MonoBehaviour
{
    #region Singleton Quickversion
    public static Logger LoggerInstance;

    private void Awake()
    {
        LoggerInstance = this;
    }

    #endregion

    private void Start()
    {
        CreateDirectory();
    }

    private void CreateDirectory()
    {
        if (!Directory.Exists(Application.streamingAssetsPath + "/Logs/")) //Checks if the folder exists.
        {
            Directory.CreateDirectory(Application.streamingAssetsPath + "/Logs/"); //Creates the folder.
        }
    }

    public void CreateTextFile(string description)
    {

        string txtDocumentName = Application.streamingAssetsPath + "/Logs/" + "Timestamp" + ".txt"; //Creates the text file in the directory in start.

        if (!File.Exists(txtDocumentName)) //Checks if the text file already exists.
        {
            File.WriteAllText(txtDocumentName, "TIMESTAMPS: \n \n"); //Creates a header for the txt file if it doesent exist. 
        }

        File.AppendAllText(txtDocumentName, description + DateTime.Now + "\n"); //Sends to log. 
    }

    public void WriteToTxtFile(string description)
    {

        string path = Application.streamingAssetsPath + "/Logs/" + "Timestamp" + ".txt";
        //Write some text to the .txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(description + DateTime.Now);
        writer.Close();
        StreamReader reader = new StreamReader(path);
        //Print the text from the file
        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }
}
