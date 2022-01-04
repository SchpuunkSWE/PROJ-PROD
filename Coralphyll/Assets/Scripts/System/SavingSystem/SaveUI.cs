using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveUI : MonoBehaviour
{
    public int level;


    [SerializeField] GameObject autosaveUI;
    public static bool isAutoSaving = false;
    [SerializeField] Animator animator;
    [SerializeField] RectTransform fxHolder;
    [SerializeField] Image AutoSaveCircle;
    [SerializeField] [Range(0, 1)] float progress = 0;


    //[SerializeField] Animation anim;
    //[SerializeField] Text txtProgress;


    public void SaveGame()
    {
        SaveSystem.SaveGame();
        
        if (SaveData.SaveData(level) = "1")
        {

        }
    }

    public void LoadGame()
    {
        SaveSystem.LoadGame();
        //level = data.level;


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
    }

    public void PlaySavingAnim()
    {

        
        animator.SetBool("isAutoSaving", true);
        StartCoroutine(wait());
        

    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(4);
        animator.SetBool("isAutoSaving", false);
    }
}
