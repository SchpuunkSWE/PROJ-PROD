using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManagerUI : MonoBehaviour
{

    [SerializeField] GameObject level1UI;
    [SerializeField] GameObject level2UI;
    [SerializeField] GameObject level3UI;
    [SerializeField] GameObject level4UI;

    public static int sceneCount;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void LoadGame()
    {
        SaveSystem.LoadGame();
        //level = data.level;
        //level = SaveSystem.data.level;

        //SaveData data = SaveSystem.data;
        //data.level = 
    }




    // Update is called once per frame
    void Update()
    {

        //data.level = level;
        SaveData data = SaveSystem.data;
        if (data != null)
        {
            //SaveData data = SaveSystem.data;

            if (data.level == 1)
            {
                level1UI.SetActive(true);
                level2UI.SetActive(false);
                level3UI.SetActive(false);
                level4UI.SetActive(false);
            }
            else if (data.level == 2)
            {
                level2UI.SetActive(true);
                level1UI.SetActive(false);
                level3UI.SetActive(false);
                level4UI.SetActive(false);
            }
            else if (data.level == 3)
            {
                level3UI.SetActive(true);
                level1UI.SetActive(false);
                level2UI.SetActive(false);
                level4UI.SetActive(false);
            }
            else if (data.level == 4)
            {
                level4UI.SetActive(true);
                level1UI.SetActive(false);
                level2UI.SetActive(false);
                level3UI.SetActive(false);
            } else
            {
                level1UI.SetActive(false);
                level2UI.SetActive(false);
                level3UI.SetActive(false);
                level4UI.SetActive(false);
            }

        }

        


    }
}
