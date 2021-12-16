using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMaterial : MonoBehaviour
{
    private MeshRenderer mRenderer;
    //Color colour;
    void Awake()
    {
        mRenderer = GetComponent<MeshRenderer>();
        //colour = mRenderer.material.color;
        //colour.a = 0.0f;
        //mRenderer.material.SetColor("_Color", colour);
        mRenderer.material.SetColor("_Color", new Color(1.0f, 1.0f, 1.0f, 0.0f));
    }

}
