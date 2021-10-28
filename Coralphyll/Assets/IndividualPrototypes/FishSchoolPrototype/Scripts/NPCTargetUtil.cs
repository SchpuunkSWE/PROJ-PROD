using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTargetUtil : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> listOfFishes = new List<GameObject>();
    [SerializeField]
    private GameObject[] arrayOfTargets; //Populera i editorn

    public int AddToSchool(GameObject go) 
    {
        if(listOfFishes.Count >= arrayOfTargets.Length || listOfFishes.Contains(go))//Om det inte finns plats eller om fisken redan finns i listan...
        {
            return -1; //returner default värde eftersom positionInList inte kan sättas till null
        }
        //Om metoden inte har returnerats...
        listOfFishes.Add(go); 
        return listOfFishes.IndexOf(go);
    }

    public GameObject GetTargetPositionObject(int i) //Hämtar TargetObject från array
    {
        return arrayOfTargets[i];
    }
}
