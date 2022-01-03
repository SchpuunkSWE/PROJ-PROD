using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Events;

[Serializable]
public class ColorEvent : UnityEvent<Color> { }
public class ColorPicker : MonoBehaviour
{
    public TextMeshProUGUI DebugText;
    public ColorEvent onColorPreview;
    public GameObject colorPickerImage;
    public Image color1Image;
    public Image color2Image;
    public Image color3Image;
    public GameObject greyOutPanel; 

    RectTransform rect;
    Texture2D colorTexture;
    
    Color colorThatsBeingPicked;
    int colorSlotThatsBeingChanged;

    //get fishes materials
    public Material material1;
    public Material material2;
    public Material material3;
    Color material1DefaultColor;
    Color material2DefaultColor;
    Color material3DefaultColor; 

    // Start is called before the first frame update
    void Start()
    {
        rect = colorPickerImage.GetComponent<RectTransform>();
        
        colorTexture = colorPickerImage.GetComponent<Image>().mainTexture as Texture2D;

        colorSlotThatsBeingChanged = 0;

        SaveTheDefaultColors();
    }

    void Update()
    {
        
        //klicka bara i rutan
        if (RectTransformUtility.RectangleContainsScreenPoint(rect, Input.mousePosition))
        {

            Vector2 delta;
            //hitta punkten på skärmen inne i rutan
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, Input.mousePosition, null, out delta);

            string debug = "mousePosition=" + Input.mousePosition;
            debug += "<br>delta=" + delta;

            //göra så det bra räknas innanför lilla rutan
            float width = rect.rect.width;
            float height = rect.rect.height;
            delta += new Vector2(width * .5f, height * .5f);
            debug += "<br>offset delta=" + delta;

            //gör det till 0-1
            float x = Mathf.Clamp(delta.x / width, 0f, 1f);
            float y = Mathf.Clamp(delta.y / height, 0f, 1f);
            debug += "<br>x=" + x + "y=" + y;

            //hitta färgen vi hovrar över
            int texX = Mathf.RoundToInt(x * colorTexture.width);
            int texY = Mathf.RoundToInt(y * colorTexture.height);
            debug += "<br>texX=" + texX + "texY=" + texY;

            //ge ut färgen
            colorThatsBeingPicked = colorTexture.GetPixel(texX, texY);

            DebugText.color = colorThatsBeingPicked;
            DebugText.text = debug;

            //visa preview
            onColorPreview?.Invoke(colorThatsBeingPicked);
            //vid klick på färg
            if (Input.GetMouseButtonDown(0))
            {
                ChangeColor(colorThatsBeingPicked);
            }
        }
    }

    void OnApplicationQuit()
    {
        ResetColors();
        //Debug.Log("default putback");
    }

    void ResetColors()
    {
        //turn everything back to default
        material1.color = material1DefaultColor;
        material2.color = material2DefaultColor;
        material3.color = material3DefaultColor;
    }

    void SaveTheDefaultColors()
    {
        material1DefaultColor = material1.color;
        material2DefaultColor = material2.color;
        material3DefaultColor = material3.color;
        //Debug.Log("default saved");
    }

    void ChangeColor(Color newColor)
    {
        if (colorSlotThatsBeingChanged.Equals(1))
        {
            material1.color = newColor;
            color1Image.color = newColor;
            greyOutPanel.SetActive(true);
        }
        else if (colorSlotThatsBeingChanged.Equals(2))
        {
            material2.color = newColor;
            color2Image.color = newColor;
            greyOutPanel.SetActive(true);
        }
        else if (colorSlotThatsBeingChanged.Equals(3))
        {
            material3.color = newColor;
            color3Image.color = newColor;
            greyOutPanel.SetActive(true);
        }
        else
        {
            Debug.Log("ERROR: colorSlotThatsBeingChanged is not 1, 2 or 3");
        }
    }

    //what button is being pressed. All the methods are connected to a button each
    public void PickColor1()
    {
        //Debug.Log("picking color1");
        colorSlotThatsBeingChanged = 1;
    }

    public void PickColor2()
    {
        //Debug.Log("picking color2");
        colorSlotThatsBeingChanged = 2;
    }

    public void PickColor3()
    {
        //Debug.Log("picking color3");
        colorSlotThatsBeingChanged = 3;
    }
}
