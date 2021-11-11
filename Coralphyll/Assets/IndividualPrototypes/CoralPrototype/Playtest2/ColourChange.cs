using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour
{

    [SerializeField] Color[] myColours;
    [SerializeField] [Range(0f, 1f)] float lerpTime;
    private MeshRenderer mRenderer;

    private Color meshColour; 
    private int colourIndex = 0;
    private float t = 0f;

    private void Awake()
    {
        mRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    void Update()
    {
        mRenderer.material.SetColor("_BaseColor", LerpColour());
    }

    private Color LerpColour()
    {
        meshColour = Color.Lerp(meshColour, myColours[colourIndex], lerpTime * Time.deltaTime);

        //Change colour-index
        t = Mathf.Lerp(t, 1f, lerpTime * Time.deltaTime);
        if (t > 0.9f)
        {
            t = 0f;
            colourIndex++;
            //Reset colourIndex when it's greater than or equal to array length
            colourIndex = (colourIndex >= myColours.Length) ? 0 : colourIndex;
        }
        return meshColour;
    }
}
