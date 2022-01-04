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
        //level = SceneManager.GetActiveScene().buildIndex;
        //level = SceneManager.GetSceneAt().buildIndex;
        
        /*
        string output = "";
        for (int n = 0; n < SceneManager.sceneCount; ++n)
        {
            Scene scene = SceneManager.GetSceneAt(n);
            output += scene.name;
            output += scene.isLoaded ? " (Loaded, " : " (Not Loaded, ";
            //output += scene.isDirty ? "Dirty, " : "Clean, ";
            output += scene.buildIndex >= 0 ? " in build)\n" : " NOT in build)\n";
        }
        */





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
        
        //autosaveUI.SetActive(true);
        //isAutoSaving = true;
        //new WaitForSeconds(5);
        //animator.SetBool("isAutoSaving", false);
        /*
        if (isAutoSaving)
        {
            new WaitForSeconds(5);
            animator.SetBool("isAutoSaving", false);
            //anim.Play("NewAutoSave");
            isAutoSaving = false;
            //autosaveUI.SetActive(false);
        }*/

    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(4);
        animator.SetBool("isAutoSaving", false);
    }
}
