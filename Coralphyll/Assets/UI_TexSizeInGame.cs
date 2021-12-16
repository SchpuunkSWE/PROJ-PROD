using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_TexSizeInGame : MonoBehaviour
{
    public GameObject getBackObject;
    private Text getBackText;

    public int DeafaultTextSizeTT1;
    public int TT1_Size1;
    public int TT1_Size2;
    public int TT1_Size3;
    public int TT1_Size4;
    public int TT1_Size5;

    private float targetSize;

    // Start is called before the first frame update
    void Start()
    {
        getBackText = getBackObject.GetComponent<Text>();
        targetSize = PlayerPrefs.GetFloat("textSize");
        changeTextSize(targetSize);

       
    }

    //TA bort detta, borde egentligen ha ett riktigt sccript för knappar i själva spelet

    public void pushButton(){
        SceneManager.LoadScene(0);
    }

    private void changeTextSize(float value){
        switch(value) {
            case 0:
               getBackText.fontSize = DeafaultTextSizeTT1;

                break;
            case 1:
                getBackText.fontSize = TT1_Size1;

                break;
            case 2:
               getBackText.fontSize = TT1_Size2;

                break;
            case 3:
                getBackText.fontSize = TT1_Size3;

                break;
            case 4:
               getBackText.fontSize = TT1_Size4;

                break;
            case 5:
                getBackText.fontSize = TT1_Size5;
  
                break;
        }

    }



}
