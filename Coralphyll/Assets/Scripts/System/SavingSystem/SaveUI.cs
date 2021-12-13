using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveUI : MonoBehaviour
{
    [SerializeField] GameObject autosaveUI;
    public static bool isAutoSaving = false;
    //[SerializeField] Animation anim;
    
    [SerializeField] Animator animator;

    [SerializeField] RectTransform fxHolder;
    [SerializeField] Image AutoSaveCircle;
    //[SerializeField] Text txtProgress;

    [SerializeField] [Range(0, 1)] float progress = 0;
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
