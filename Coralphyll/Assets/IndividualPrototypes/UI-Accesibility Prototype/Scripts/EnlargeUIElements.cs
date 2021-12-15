using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnlargeUIElements : MonoBehaviour
{

    private Vector3 baseSize;
    // Start is called before the first frame update
    void Start()
    {
        baseSize = this.gameObject.transform.localScale;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnlargeButton (){
       
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);

    }

    public void DecreaseButton (){

        transform.localScale = baseSize;
    }
}
