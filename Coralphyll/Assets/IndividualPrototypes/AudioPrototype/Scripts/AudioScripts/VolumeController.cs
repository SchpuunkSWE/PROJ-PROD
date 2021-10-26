using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class VolumeController : MonoBehaviour
{

    [SerializeField] string volumeValueMaster;
    [SerializeField] string volumeValueChase;
    //    [SerializeField] AudioMixer mixer;
    [SerializeField] private Text volumePercentageMaster;
    [SerializeField] private Slider sliderMaster;
    [SerializeField] private Text volumePercentageAmbience;
    [SerializeField] private Slider sliderAmbience;

    private string volString;
    private int volPerc1;
    private int volPerc2;
    private void Awake()
    {
        sliderMaster.onValueChanged.AddListener(VolumeChangeMaster);
        sliderAmbience.onValueChanged.AddListener(VolumeChangeChase);
        sliderMaster.minValue = 0.001f;
        sliderAmbience.minValue = 0.001f;
    }

    void Start()
    {
        sliderMaster.value = PlayerPrefs.GetFloat(volumeValueMaster, sliderMaster.value);
        sliderAmbience.value = PlayerPrefs.GetFloat(volumeValueChase, sliderAmbience.value);
    }
    private void OnDisable()
    {
        PlayerPrefs.SetFloat(volumeValueMaster, sliderMaster.value);
        PlayerPrefs.SetFloat(volumeValueChase, sliderAmbience.value);
    }

    private void VolumeChangeMaster(float value)
    {
        volPerc1 = (int)(100 * value);
        volString = volPerc1 + " %";
        volumePercentageMaster.text = volString;
    }
    private void VolumeChangeChase(float value)
    {
        volPerc2 = (int)(100 * value);
        volString = volPerc2 + " %";
        volumePercentageAmbience.text = volString;
    }
   /* public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }*/

}
