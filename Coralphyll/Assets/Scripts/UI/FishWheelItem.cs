using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishWheelItem : MonoBehaviour
{
    public Color hoverColor;
    public Color baseColor;
    public Image background;
    

    // Start is called before the first frame update
    void Start()
    {
        background.color = baseColor;
        
    }

    // Update is called once per frame
 

    public void Select()
    {
        background.color = hoverColor;

    }

    public void DeSelect()
    {
        background.color = baseColor;

    }
}
