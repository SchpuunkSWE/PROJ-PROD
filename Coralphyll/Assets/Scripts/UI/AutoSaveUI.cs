using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoSaveUI : MonoBehaviour
{
    [SerializeField] RectTransform fxHolder;
    [SerializeField] Image AutoSaveCircle;
    //[SerializeField] Text txtProgress;

    [SerializeField] [Range(0, 1)] float progress = 0;

    // Update is called once per frame
    void Update()
    {
        AutoSaveCircle.fillAmount = progress;
        //txtProgress.text = Mathf.Floor(progress * 100).ToString();
        fxHolder.rotation = Quaternion.Euler(new Vector3(0f, 0f, -progress * 360));

    }
}
