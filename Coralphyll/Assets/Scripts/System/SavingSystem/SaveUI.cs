using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveUI : MonoBehaviour
{
    //private int level;


    [SerializeField] GameObject autosaveUI;
    public static bool isAutoSaving = false;
    [SerializeField] Animator animator;
    [SerializeField] RectTransform fxHolder;
    [SerializeField] Image AutoSaveCircle;
    [SerializeField] [Range(0, 1)] float progress = 0;

    [SerializeField] GameObject level1UI;
    [SerializeField] GameObject level2UI;
    [SerializeField] GameObject level3UI;
    [SerializeField] GameObject level4UI;

    //[SerializeField] Animation anim;
    //[SerializeField] Text txtProgress;


    public void SaveGame()
    {
        SaveSystem.SaveGame();

        

        /*
        if (SaveData.SaveData(level) = "1")
        {

        }
        */
    }

    public void LoadGame()
    {
        SaveSystem.LoadGame();
        //level = data.level;
        //level = SaveSystem.data.level;

        //SaveData data = SaveSystem.data;
        //data.level = 
    }


    void Start()
    {
        //anim = gameObject.GetComponent<Animation>();
        autosaveUI.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
       
        AutoSaveCircle.fillAmount = progress;
        //txtProgress.text = Mathf.Floor(progress * 100).ToString();
        fxHolder.rotation = Quaternion.Euler(new Vector3(0f, 0f, -progress * 360));
        //animator.SetBool("isAutoSaving", false);
        
        if(isAutoSaving)
        {
            PlaySavingAnim();
        }

        SaveData data = SaveSystem.data;
        //data.level = level;

        if (data.level == 1)
        {
            level1UI.SetActive(true);
            level2UI.SetActive(false);
            level3UI.SetActive(false);
            level4UI.SetActive(false);
        }
        if (data.level == 2)
        {
            level2UI.SetActive(true);
            level1UI.SetActive(false);
            level3UI.SetActive(false);
            level4UI.SetActive(false);
        }
        if (data.level == 3)
        {
            level3UI.SetActive(true);
            level1UI.SetActive(false);
            level2UI.SetActive(false);
            level4UI.SetActive(false);
        }
        if (data.level == 4)
        {
            level4UI.SetActive(true);
            level1UI.SetActive(false);
            level2UI.SetActive(false);
            level3UI.SetActive(false);
        }
    }

    public void PlaySavingAnim()
    {

        SaveSystem.SaveGame();
        animator.SetBool("isAutoSaving", true);
        StartCoroutine(wait());
        

    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(4);
        animator.SetBool("isAutoSaving", false);
    }
}
