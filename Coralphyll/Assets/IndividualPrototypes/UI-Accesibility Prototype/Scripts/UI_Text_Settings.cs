using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UI_Text_Settings : MonoBehaviour
{
    public GameObject StartButtonObject;
    public GameObject OptionButtonObject;
    public GameObject HowToPlayButtonObject;
    public GameObject VisualButtonObject;
   // public GameObject AudioButtonObject;
   // public GameObject ControlButtonObject;
    public GameObject UIOptionsObject;
    public GameObject TextSizeObject;
    //public GameObject TextBackgroundObject;
    public GameObject TextToSpeachObject;

    public GameObject[] tt1GO;
    public GameObject[] tt2GO;
    public GameObject[] tt3GO;
    //public GameObject VisualAidObject;
    public TextMeshPro[] tt1Text;
    public Text[] tt2Text;
    public Text[] tt3Text;
    private  TextMeshProUGUI font;
    private RectTransform m_RectTransform;




    private Text StartButtonText;
    private Text OptionButtonText;
    private Text HowToPlayButtonText;
    private Text VisualButtonText;
    //private Text AudioButtonText;
    //private Text ControlButtonText;
    private Text UIOptionsText;
    private Text TextSizeText;
   // private Text TextBackgroundText;
   private Text TextToSpeachText;
   // private Text VisualAidText;


// the different text types, 
//headers are TT1, Buttons TT2, text bodies are TT3 etc
    private int TT1;
    private int TT2;

    private int TT3;

    public int DeafaultTextSizeTT1;
    public int DeafaultTextSizeTT2;
    public int DeafaultTextSizeTT3;
    public float targetSize;

    public int TT1_Size1 = 15;
    public int TT1_Size2 = 20;
    public int TT1_Size3 = 25;
    public int TT1_Size4;
    public int TT1_Size5;
    
    public int TT2_Size1;
    public int TT2_Size2;
    public int TT2_Size3;
    public int TT2_Size4;
    public int TT2_Size5;

    public int TT3_Size1;
    public int TT3_Size2;
    public int TT3_Size3;
    public int TT3_Size4;
    public int TT3_Size5;





    // Start is called before the first frame update
    void Start()
    {
        assignTextToGameobject();
        changeTextSize(0);



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void valueChanged(float value){
        targetSize = value;
        changeTextSize(targetSize);
        
    }

    private void assignTextToGameobject(){
        StartButtonText = StartButtonObject.GetComponent<Text>();
        OptionButtonText = OptionButtonObject.GetComponent<Text>();
        HowToPlayButtonText = HowToPlayButtonObject.GetComponent<Text>();
        VisualButtonText = VisualButtonObject.GetComponent<Text>();
      //  AudioButtonText = AudioButtonObject.GetComponent<Text>();
       // ControlButtonText = ControlButtonObject.GetComponent<Text>();
        UIOptionsText = UIOptionsObject.GetComponent<Text>();
        TextSizeText = TextSizeObject.GetComponent<Text>();
       // TextBackgroundText = TextBackgroundObject.GetComponent<Text>();
       TextToSpeachText = TextToSpeachObject.GetComponent<Text>();
       // VisualAidText = VisualAidObject.GetComponent<Text>();
      /* foreach (GameObject i in tt1GO)
                {
                    
                     tt1Text[tt1GO.Length] = (i.GetComponent<TextMeshPro>());
                }
                */


    }

    private void changeTextSize(float value){
        changetextsizeTT1(value);
        changetextsizeTT2(value);
        changetextsizeTT3(value);
        PlayerPrefs.SetFloat("textSize", value);

    }

    private void changetextsizeTT1(float value){
        switch(value) {
            case 0:
               StartButtonText.fontSize = DeafaultTextSizeTT1;
               Debug.Log("jag ändrade mig till TT1");
               OptionButtonText.fontSize = DeafaultTextSizeTT1;
               HowToPlayButtonText.fontSize  = DeafaultTextSizeTT1;
               //UIOptionsText.fontSize  = DeafaultTextSizeTT1;
              // VisualAidText.fontSize = DeafaultTextSizeTT1;
              foreach (GameObject i in tt1GO)
                {
                  
                    font =  i.GetComponent<TextMeshProUGUI>();
                    font.fontSize = 40f;

                }
              
                break;
            case 1:
                StartButtonText.fontSize = TT1_Size1;
                OptionButtonText.fontSize = TT1_Size1;
                HowToPlayButtonText.fontSize  = TT1_Size1;
                UIOptionsText.fontSize  = TT1_Size1;
                //VisualAidText.fontSize = TT1_Size1;
                foreach (GameObject i in tt1GO)
                {
                  
                    font =  i.GetComponent<TextMeshProUGUI>();
                    font.fontSize = 50f;
                    m_RectTransform = font.GetComponent<RectTransform>();
                    m_RectTransform.sizeDelta = new Vector2(font.fontSize * 10, 100);
                }
                break;
            case 2:
               StartButtonText.fontSize = TT1_Size2;
               OptionButtonText.fontSize = TT1_Size2;
               HowToPlayButtonText.fontSize  = TT1_Size2;
              // UIOptionsText.fontSize  = TT1_Size2;
              // VisualAidText.fontSize = TT1_Size2;
              foreach (GameObject i in tt1GO)
                {
                  
                    font =  i.GetComponent<TextMeshProUGUI>();
                    font.fontSize = 55f;
                    m_RectTransform = font.GetComponent<RectTransform>();
                    m_RectTransform.sizeDelta = new Vector2(font.fontSize * 10, 100);
                }
                break;
            case 3:
                StartButtonText.fontSize = TT1_Size3;
                OptionButtonText.fontSize = TT1_Size3;
                HowToPlayButtonText.fontSize  = TT1_Size3;
                //UIOptionsText.fontSize  = TT1_Size3;
                //VisualAidText.fontSize = TT1_Size3;
                foreach (GameObject i in tt1GO)
                {
                  
                    font =  i.GetComponent<TextMeshProUGUI>();
                    font.fontSize = 60f;
                    m_RectTransform = font.GetComponent<RectTransform>();
                    m_RectTransform.sizeDelta = new Vector2(font.fontSize * 10, 100);
                }
                break;
            case 4:
               StartButtonText.fontSize = TT1_Size4;
               OptionButtonText.fontSize = TT1_Size4;
               HowToPlayButtonText.fontSize  = TT1_Size4;
              // UIOptionsText.fontSize  = TT1_Size4;
               //VisualAidText.fontSize = TT1_Size4;
               foreach (GameObject i in tt1GO)
                {
                  
                    font =  i.GetComponent<TextMeshProUGUI>();
                    font.fontSize = 70f;
                    m_RectTransform = font.GetComponent<RectTransform>();
                    m_RectTransform.sizeDelta = new Vector2(font.fontSize * 10, 100);
                }
                break;
            case 5:
                StartButtonText.fontSize = TT1_Size5;
                OptionButtonText.fontSize =TT1_Size5;
                HowToPlayButtonText.fontSize  = TT1_Size5;
                //UIOptionsText.fontSize  = TT2_Size5;
                //VisualAidText.fontSize = TT2_Size5;
                foreach (GameObject i in tt1GO)
                {
                  
                    font =  i.GetComponent<TextMeshProUGUI>();
                    font.fontSize = 100f;
                    m_RectTransform = font.GetComponent<RectTransform>();
                    m_RectTransform.sizeDelta = new Vector2(font.fontSize * 10, 100);
                }
                break;
            }
                
    }
    private void changetextsizeTT2(float value){

        switch(value) {
            case 0:
               VisualButtonText.fontSize = DeafaultTextSizeTT2;
               TextSizeText.fontSize = DeafaultTextSizeTT2;
               UIOptionsText.fontSize = DeafaultTextSizeTT2;
               TextToSpeachText.fontSize = DeafaultTextSizeTT2;

                break;
            case 1:
                VisualButtonText.fontSize = TT2_Size1;
                TextSizeText.fontSize = TT2_Size1;
                UIOptionsText.fontSize = TT2_Size1;
                TextToSpeachText.fontSize = TT2_Size1;

                break;
            case 2:
               VisualButtonText.fontSize = TT2_Size2;
               TextSizeText.fontSize = TT2_Size2;
               UIOptionsText.fontSize = TT2_Size2;
               TextToSpeachText.fontSize = TT2_Size2;

                break;
            case 3:
                VisualButtonText.fontSize = TT2_Size3;
                TextSizeText.fontSize = TT2_Size3;
                UIOptionsText.fontSize = TT2_Size3;
                TextToSpeachText.fontSize = TT2_Size3;

                break;
            case 4:
               VisualButtonText.fontSize = TT2_Size4;
               TextSizeText.fontSize = TT2_Size4;
               UIOptionsText.fontSize = TT2_Size4;
               TextToSpeachText.fontSize = TT2_Size4;

                break;
            case 5:
                VisualButtonText.fontSize = TT2_Size5;
                TextSizeText.fontSize =TT2_Size5;
                UIOptionsText.fontSize = TT2_Size5;
                TextToSpeachText.fontSize = TT2_Size5;
                

                break;
            }
        
    }

    private void changetextsizeTT3(float value){
        /*

        switch(value) {
            case 0:
              /* StartButtonText.fontSize = DeafaultTextSizeTT1;
               OptionButtonText.fontSize = DeafaultTextSizeTT1;
               HowToPlayButtonText.fontSize  = DeafaultTextSizeTT1;
               UIOptionsText.fontSize  = DeafaultTextSizeTT1;
               //VisualAidText.fontSize = DeafaultTextSizeTT1;
               StartButtonText.fontSize = DeafaultTextSizeTT1;
               
                break;
            case 1:
                StartButtonText.fontSize = TT3_Size1;
                OptionButtonText.fontSize = TT3_Size1;
                HowToPlayButtonText.fontSize  = TT3_Size1;
                UIOptionsText.fontSize  = TT3_Size1;
               // VisualAidText.fontSize = TT3_Size1;
                StartButtonText.fontSize = TT3_Size1;
                break;
            case 2:
               StartButtonText.fontSize = TT3_Size2;
               OptionButtonText.fontSize = TT3_Size2;
               HowToPlayButtonText.fontSize  = TT3_Size2;
               UIOptionsText.fontSize  = TT3_Size2;
              // VisualAidText.fontSize = TT3_Size2;
               StartButtonText.fontSize = TT3_Size2;
                break;
            case 3:
                StartButtonText.fontSize = TT3_Size3;
                OptionButtonText.fontSize = TT3_Size3;
                HowToPlayButtonText.fontSize  = TT3_Size3;
                UIOptionsText.fontSize  = TT3_Size3;
              //  VisualAidText.fontSize = TT3_Size3;
                StartButtonText.fontSize = TT3_Size3;
                break;
            case 4:
               StartButtonText.fontSize = TT3_Size4;
               OptionButtonText.fontSize = TT3_Size4;
               HowToPlayButtonText.fontSize  = TT3_Size4;
               UIOptionsText.fontSize  = TT3_Size4;
              // VisualAidText.fontSize = TT3_Size4;
               StartButtonText.fontSize = TT3_Size4;
                break;
            case 5:
                StartButtonText.fontSize = TT3_Size5;
                OptionButtonText.fontSize =TT3_Size5;
                HowToPlayButtonText.fontSize  = TT3_Size5;
                UIOptionsText.fontSize  = TT3_Size5;
              //  VisualAidText.fontSize = TT3_Size5;
                StartButtonText.fontSize = TT3_Size5;
                break;
            }
            */
        
    }
}
