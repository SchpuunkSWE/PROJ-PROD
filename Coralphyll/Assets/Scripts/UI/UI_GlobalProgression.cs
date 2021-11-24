using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GlobalProgression : MonoBehaviour
{
    public Slider c1Yellow;
    public Slider c1Red;
    public Slider c1Blue;
    public Slider c2Yellow;
    public Slider c2Red;
    public Slider c2Blue;

    public Slider c3Yellow;
    public Slider c3Red;
    public Slider c3Blue;
    public GameObject coral1UI;
    public GameObject coral2UI;
    public GameObject coral3UI;
    private Image coral1I;
    private Image coral2I;
    private Image coral3I;

    
    
    
    private int maxAmountProcent;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setGlobalProgression(int coralNr, int color, int fishAmount, int fishNeeded)
    {
        //witch coral does this work on
        setCurrentCoral(coralNr);
        Debug.Log("Set current coral");

    
                switch(color) 
                {
                    case 0:
                    

                        changeYellowSlider (coralNr, fishAmount, fishNeeded);
                        
                        break;
                    case 1:
                        changeRedSlider (coralNr, fishAmount, fishNeeded);
                        
                        break;
                    case 2:
                        changeBlueSlider (coralNr, fishAmount, fishNeeded);
                        break;
                    default:
                        // code block
                        break;
                }
    }

    private void changeRedSlider(int coralNr, int fishAmount, int fishNeeded){
        switch(coralNr) 
            {
            case 1:
    
                //100/ maxamount
                maxAmountProcent = 100 / fishNeeded;
                //multiply with fishamount
                c1Red.value = maxAmountProcent * fishAmount;
                break;
            case 2:
                maxAmountProcent = 100 / fishNeeded;
                c2Red.value = maxAmountProcent * fishAmount;
                
                break;
            case 3:
                maxAmountProcent = 100 / fishNeeded;
                c3Red.value = maxAmountProcent * fishAmount;
                
                break;
            default:
                break;
            }

    }
    private void changeYellowSlider(int coralNr, int fishAmount, int fishNeeded){
        
        switch(coralNr) 
            {
            case 1:
    
                //100/ maxamount
                maxAmountProcent = 100 / fishNeeded;
                //multiply with fishamount
                c1Yellow.value = maxAmountProcent * fishAmount;
                break;
            case 2:
                maxAmountProcent = 100 / fishNeeded;
                c2Yellow.value = maxAmountProcent * fishAmount;
                
                break;
            case 3:
                maxAmountProcent = 100 / fishNeeded;
                c3Yellow.value = maxAmountProcent * fishAmount;
                
                break;
            default:
                break;
            }

    }
    private void changeBlueSlider(int coralNr, int fishAmount, int fishNeeded)
    {
        switch(coralNr) 
            {
            case 1:
    
                //100/ maxamount
                maxAmountProcent = 100 / fishNeeded;
                //multiply with fishamount
                c1Blue.value = maxAmountProcent * fishAmount;
                break;
            case 2:
                maxAmountProcent = 100 / fishNeeded;
                c2Blue.value = maxAmountProcent * fishAmount;
                
                break;
            case 3:
                maxAmountProcent = 100 / fishNeeded;
                c3Blue.value = maxAmountProcent * fishAmount;
                
                break;
            default:
                break;
            }

    }

    private void OpenCoralPanels(){

    }

    private void setCurrentCoral(int coralNr){
         switch(coralNr) 
            {
            case 1:
            coral1I = coral1UI.GetComponent<Image>();
            coral1UI.GetComponent<Image>().color = new Color(coral1I.color.r,coral1I.color.g,coral1I.color.b, 1f);
            Debug.Log(coral1UI.GetComponent<Image>().color);
            coral2I = coral2UI.GetComponent<Image>();
            coral2UI.GetComponent<Image>().color = new Color(coral1I.color.r,coral1I.color.g,coral1I.color.b, 0.5f);
            Debug.Log(coral2UI);
            coral3I = coral3UI.GetComponent<Image>();
            coral3I.color = new Color(coral1I.color.r,coral1I.color.g,coral1I.color.b, 0.5f);

                break;
            case 2:
            coral1I = coral1UI.GetComponent<Image>();
            coral1I.color = new Color(coral1I.color.r,coral1I.color.g,coral1I.color.b, 0.5f);
            coral2I = coral2UI.GetComponent<Image>();
            coral2I.color = new Color(coral1I.color.r,coral1I.color.g,coral1I.color.b, 1f);
            coral3I = coral3UI.GetComponent<Image>();
            coral3I.color = new Color(coral1I.color.r,coral1I.color.g,coral1I.color.b, 0.5f);
                
                
                break;
            case 3:
            coral1I = coral1UI.GetComponent<Image>();
            coral1I.color = new Color(coral1I.color.r,coral1I.color.g,coral1I.color.b, 0.5f);
            coral2I = coral2UI.GetComponent<Image>();
            coral2I.color = new Color(coral1I.color.r,coral1I.color.g,coral1I.color.b, 0.5f);
            coral3I = coral3UI.GetComponent<Image>();
            coral3I.color = new Color(coral1I.color.r,coral1I.color.g,coral1I.color.b, 1f);
                
                
                break;
            default:
            setDefaultCoralImageColor();
         
                break;
            }

    }
    private void setDefaultCoralImageColor(){
        coral1I = coral1UI.GetComponent<Image>();
        coral1I.color = new Color(coral1I.color.r,coral1I.color.g,coral1I.color.b, 1f);
        coral2I = coral2UI.GetComponent<Image>();
        coral1I.color = new Color(coral1I.color.r,coral1I.color.g,coral1I.color.b, 1f);
        coral3I = coral3UI.GetComponent<Image>();
        coral1I.color = new Color(coral1I.color.r,coral1I.color.g,coral1I.color.b, 1f);

    }
}
