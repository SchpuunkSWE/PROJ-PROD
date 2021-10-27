using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTargetUtil : MonoBehaviour
{
    [SerializeField]
    private List<Follower> listOfFishes = new List<Follower>();
    private List<Follower> fishesToRemove = new List<Follower>();
    [SerializeField]
    private GameObject[] arrayOfTargets; //Populera i editorn

    public int AddToSchool(Follower go) //Kanske döpa om (till AddTOInventory)
    {
        if(listOfFishes.Count >= arrayOfTargets.Length || listOfFishes.Contains(go))//Om det inte finns plats eller om fisken redan finns i listan...
        {
            return -1; //returner default v�rde eftersom positionInList inte kan s�ttas till null
        }
        //Om metoden inte har returnerats...
        listOfFishes.Add(go); 
        return listOfFishes.IndexOf(go);
    }

    public GameObject GetTargetPositionObject(int i) //H�mtar TargetObject fr�n array
    {
        return arrayOfTargets[i];
    }

    public List<Follower> getListOfFishes()
    {
        return listOfFishes;
    }

    public void Update()
    {
        foreach(Follower f in listOfFishes)
        {
            if(!f.gameObject.activeSelf)
            {
                fishesToRemove.Add(f);
            }
        }
        foreach(Follower f in fishesToRemove)
        {
            listOfFishes.Remove(f);
            //Destroy(f.gameObject); typ
        }
    }
}
