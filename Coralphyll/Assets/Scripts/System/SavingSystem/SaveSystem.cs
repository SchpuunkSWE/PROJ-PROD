using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveSystem : MonoBehaviour
{
    private static bool isLoading = false; //Used to see if we need to load data or not
    private static SaveData data; //Variable to save our data as

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static bool IsLoading
    {
        get => isLoading;
        set => isLoading = value;
    }

    static void OnSceneLoaded(Scene scene, LoadSceneMode mode) //Method added to scenemanager to run when scene has finished loading, Loading our player and scene data
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
        /*
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            return;
        }
        */


        if (isLoading == true)
        {

            SaveSystem.IsLoading = false;
            Debug.Log("Loaded");
        }
    }
    public static void LoadBetweenLevels() //Method used för loading data between scenes(use for all corals??)
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public static void LoadGame() //Method för loading data from menu after complete save
    {
        SaveData data = LoadData("/Kame.lol");
        if (data != null)
        {
            isLoading = true;
            SceneManager.sceneLoaded += OnSceneLoaded;
            // load scene
            SceneManager.LoadScene(data.level);
        }
    }

    public static void SaveGame() //Method for formatting and saving our data to a file
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Kame.lol";
        FileStream stream = new FileStream(path, FileMode.Create);

        data = new SaveData();

        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("Saved");
    }

    private static SaveData LoadData(string saveFile)
    {
        string path = Application.persistentDataPath + saveFile;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            data = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Savefile not found at " + path);
            return null;
        }
    }

}
