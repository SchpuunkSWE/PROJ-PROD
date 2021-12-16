using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UI_Text_Settings : MonoBehaviour
{
  //  public GameObject StartButtonObject;
   // public GameObject OptionButtonObject;
   // public GameObject HowToPlayButtonObject;
   // public GameObject VisualButtonObject;
   // public GameObject AudioButtonObject;
   // public GameObject ControlButtonObject;
    //public GameObject UIOptionsObject;
    //public GameObject TextSizeObject;
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
    private Text fonttext;
    private RectTransform m_RectTransform;

    public GameObject button;




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
    private float TT1;
    private float TT2;

    private float TT3;

    public float DeafaultTextSizeTT1;
    public int DeafaultTextSizeTT2;
    public float DeafaultTextSizeTT3;
    public float targetSize;

    public float TT1_Size1 = 15f;
    public float TT1_Size2 = 20;
    public float TT1_Size3 = 25;
    public float TT1_Size4;
    public float TT1_Size5;
    
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
      
    }

    private void changeTextSize(float value){
        changetextsizeTT1(value);
        changetextsizeTT2(value);
      //  changetextsizeTT3(value);
        PlayerPrefs.SetFloat("textSize", value);

    }

    private void changetextsizeTT1(float value){
        switch(value) {
            case 0:
            //   StartButtonText.fontSize = DeafaultTextSizeTT1;
               Debug.Log("jag ändrade mig till TT1");
          
              foreach (GameObject i in tt1GO)
                {
                  
                    font =  i.GetComponent<TextMeshProUGUI>();
                    font.fontSize = DeafaultTextSizeTT1;
                    //måste lägga till en base size
                    //transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);

                }
              
                break;
            case 1:
               
                foreach (GameObject i in tt1GO)
                {
                  
                    font =  i.GetComponent<TextMeshProUGUI>();
                    font.fontSize = TT1_Size1;
                    //m_RectTransform = font.GetComponent<RectTransform>();
                   // m_RectTransform.sizeDelta = new Vector2(font.fontSize * 10, 100);
                }
                break;
            case 2:
               
              foreach (GameObject i in tt1GO)
                {
                  
                    font =  i.GetComponent<TextMeshProUGUI>();
                    font.fontSize = TT1_Size2;
                    //m_RectTransform = font.GetComponent<RectTransform>();
                   // m_RectTransform.sizeDelta = new Vector2(font.fontSize * 10, 100);
                }
                break;
            case 3:
               
                foreach (GameObject i in tt1GO)
                {
                  
                    font =  i.GetComponent<TextMeshProUGUI>();
                    font.fontSize = TT1_Size3;
                    //m_RectTransform = font.GetComponent<RectTransform>();
                   // m_RectTransform.sizeDelta = new Vector2(font.fontSize * 10, 100);
                }
                break;
            case 4:
               
               foreach (GameObject i in tt1GO)
                {
                  
                    font =  i.GetComponent<TextMeshProUGUI>();
                    font.fontSize = TT1_Size4;
                   // m_RectTransform = font.GetComponent<RectTransform>();
                    //m_RectTransform.sizeDelta = new Vector2(font.fontSize * 10, 100);
                }
                break;
            case 5:
               
                foreach (GameObject i in tt1GO)
                {
                  
                    font =  i.GetComponent<TextMeshProUGUI>();
                    font.fontSize = TT1_Size5;
                   // m_RectTransform = font.GetComponent<RectTransform>();
                    //m_RectTransform.sizeDelta = new Vector2(font.fontSize * 10, 100);
                }
                break;
            }
                
    }
    private void changetextsizeTT2(float value){
        Debug.Log("jag kommer ändra tt2");

        switch(value) {
            case 0:
            //   StartButtonText.fontSize = DeafaultTextSizeTT1;
               Debug.Log("jag ändrade mig till TT2 0");
          
              foreach (GameObject i in tt2GO)
                {
                  
                    fonttext =  i.GetComponent<Text>();
                    fonttext.fontSize = DeafaultTextSizeTT2;

                    //måste lägga till en base size
                    //transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
                  //  Debug.Log("jag ändrade mig till TT2 default");

                }
              
                break;
            case 1:
            Debug.Log("jag ändrade mig till TT2 1");
               
                foreach (GameObject i in tt2GO)
                {
                  
                    fonttext =  i.GetComponent<Text>();
                    fonttext.fontSize = TT2_Size1;
                    //m_RectTransform = font.GetComponent<RectTransform>();
                   // m_RectTransform.sizeDelta = new Vector2(font.fontSize * 10, 100);
                 //  Debug.Log("jag ändrade mig till TT2 size 1");
                }
                break;
            case 2:
               
              foreach (GameObject i in tt2GO)
                {
                  
                    fonttext =  i.GetComponent<Text>();
                    fonttext.fontSize = TT2_Size2;
                    //m_RectTransform = font.GetComponent<RectTransform>();
                   // m_RectTransform.sizeDelta = new Vector2(font.fontSize * 10, 100);
                 //  Debug.Log("jag ändrade mig till TT2 size 2");
                }
                break;
            case 3:
               
                foreach (GameObject i in tt2GO)
                {
                  
                    fonttext =  i.GetComponent<Text>();
                    fonttext.fontSize = TT2_Size3;
                    //m_RectTransform = font.GetComponent<RectTransform>();
                   // m_RectTransform.sizeDelta = new Vector2(font.fontSize * 10, 100);
                   //Debug.Log("jag ändrade mig till TT2 size 3");
                }
                break;
            case 4:
               
               foreach (GameObject i in tt2GO)
                {
                  
                    fonttext =  i.GetComponent<Text>();
                    fonttext.fontSize = TT2_Size4;
                   m_RectTransform = font.GetComponent<RectTransform>();
                    m_RectTransform.sizeDelta = new Vector2(font.fontSize * 10, 100);
                   // Debug.Log("jag ändrade mig till TT2 size 4");
                }
                break;
            case 5:
               
                foreach (GameObject i in tt2GO)
                {
                  
                    fonttext =  i.GetComponent<Text>();
                    fonttext.fontSize = TT2_Size5;
                    m_RectTransform = font.GetComponent<RectTransform>();
                    m_RectTransform.sizeDelta = new Vector2(font.fontSize * 10, 100);
                }
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
