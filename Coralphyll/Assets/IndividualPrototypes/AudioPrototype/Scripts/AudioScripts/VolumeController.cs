using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class VolumeController : MonoBehaviour
{

    [SerializeField] string volumeValueMaster;
    [SerializeField] string volumeValueAmbience;
    [SerializeField] string volumeValueSFX;
    [SerializeField] string volumeValueMusic;
    //    [SerializeField] AudioMixer mixer;
    [SerializeField] private Text volumePercentageMaster;
    [SerializeField] private Slider sliderMaster;
    [SerializeField] private Text volumePercentageAmbience;
    [SerializeField] private Slider sliderAmbience;

    [SerializeField] private Text volumePercentageSFX;
    [SerializeField] private Slider sliderSFX;
    [SerializeField] private Text volumePercentageMusic;
    [SerializeField] private Slider sliderMusic;

    [SerializeField] private string RTPC_MasterVolume;
    [SerializeField] private string RTPC_AmbienceVolume;
    [SerializeField] private string RTPC_SFXVolume;
    [SerializeField] private string RTPC_MusicVolume;

    private string volString;
    private int volPerc1;
    private int volPerc2;
    private int volPerc3;
    private int volPerc4;
    private void Awake()
    {
        sliderMaster.onValueChanged.AddListener(VolumeChangeMaster);
        sliderAmbience.onValueChanged.AddListener(VolumeChangeAmbience);
        sliderMaster.minValue = 0.001f;
        sliderAmbience.minValue = 0.001f;

        sliderSFX.onValueChanged.AddListener(VolumeChangeSFX);
        sliderMusic.onValueChanged.AddListener(VolumeChangeMusic);
        sliderMusic.minValue = 0.001f;
        sliderSFX.minValue = 0.001f;
    }

    void Start()
    {
        sliderMaster.value = PlayerPrefs.GetFloat(volumeValueMaster, sliderMaster.value);
        sliderAmbience.value = PlayerPrefs.GetFloat(volumeValueAmbience, sliderAmbience.value);
        sliderMusic.value = PlayerPrefs.GetFloat(volumeValueMusic, sliderMusic.value);
        sliderSFX.value = PlayerPrefs.GetFloat(volumeValueSFX, sliderSFX.value);
    }
    private void OnDisable()
    {
        PlayerPrefs.SetFloat(volumeValueMaster, sliderMaster.value);
        PlayerPrefs.SetFloat(volumeValueAmbience, sliderAmbience.value);
        PlayerPrefs.SetFloat(volumeValueMusic, sliderMusic.value);
        PlayerPrefs.SetFloat(volumeValueSFX, sliderSFX.value);
    }

    private void VolumeChangeMaster(float value)
    {
        AkSoundEngine.SetRTPCValue(RTPC_MasterVolume, value * 100);
        volPerc1 = (int)(100 * value);
        volString = volPerc1 + " %";
        volumePercentageMaster.text = volString;
    }
    private void VolumeChangeAmbience(float value)
    {
        AkSoundEngine.SetRTPCValue(RTPC_AmbienceVolume, value*100);
        volPerc2 = (int)(100 * value);
        volString = volPerc2 + " %";
        volumePercentageAmbience.text = volString;
    }
    private void VolumeChangeMusic(float value)
    {
        AkSoundEngine.SetRTPCValue(RTPC_MusicVolume, value * 100);
        volPerc3 = (int)(100 * value);
        volString = volPerc3 + " %";
        volumePercentageMusic.text = volString;
    }
    private void VolumeChangeSFX(float value)
    {
        AkSoundEngine.SetRTPCValue(RTPC_SFXVolume, value * 100);
        volPerc4 = (int)(100 * value);
        volString = volPerc4 + " %";
        volumePercentageSFX.text = volString;
    }
    /* public void QuitGame()
     {
         Debug.Log("QUIT");
         Application.Quit();
     }*/

}
