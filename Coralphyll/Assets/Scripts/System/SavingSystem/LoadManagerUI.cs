using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManagerUI : MonoBehaviour
{

    [SerializeField] GameObject level1UI;
    [SerializeField] GameObject level2UI;
    [SerializeField] GameObject level3UI;
    [SerializeField] GameObject level4UI;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SaveData data = SaveSystem.data;
        //data.level = level;

        if (data.level == 1)
        {
            level1UI.SetActive(true);
            level2UI.SetActive(false);
            level3UI.SetActive(false);
            level4UI.SetActive(false);
        } else if (data.level == 2)
        {
            level2UI.SetActive(true);
            level1UI.SetActive(false);
            level3UI.SetActive(false);
            level4UI.SetActive(false);
        } else if (data.level == 3)
        {
            level3UI.SetActive(true);
            level1UI.SetActive(false);
            level2UI.SetActive(false);
            level4UI.SetActive(false);
        } else if (data.level == 4)
        {
            level4UI.SetActive(true);
            level1UI.SetActive(false);
            level2UI.SetActive(false);
            level3UI.SetActive(false);
        }


    }
}
