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
    private NavigationArrow navArrow;

    private void Awake()
    {
        navArrow = transform.gameObject.GetComponent<NavigationArrow>();
        SelectNavArrowTarget();
    }

    public int AddToSchool(Follower fol) //Kanske döpa om (till AddTOInventory)
    {
        if(listOfFishes.Count >= arrayOfTargets.Length || listOfFishes.Contains(fol))//Om det inte finns plats eller om fisken redan finns i listan...
        {
            SelectNavArrowTarget();
            return -1; //returner default v�rde eftersom positionInList inte kan s�ttas till null
        }
        //Om metoden inte har returnerats...
        listOfFishes.Add(fol);
        SelectNavArrowTarget();
        return listOfFishes.IndexOf(fol);
    }

    public GameObject GetTargetPositionObject(int i) //H�mtar TargetObject fr�n array
    {
        return arrayOfTargets[i];
    }

    public List<Follower> getListOfFishes()
    {
        return listOfFishes;
    }

    private void SelectNavArrowTarget()
    {
        if (listOfFishes.Count < arrayOfTargets.Length)
        {
            navArrow.SetTargetTag("FishSchool");
        }
        else
        {
            navArrow.SetTargetTag("Coral");
        }
    }
    private void Update()
    {
        //DepositFishes();
    }

    public void DepositFishes()
    {
        foreach (Follower f in listOfFishes)
        {
            if (!f.gameObject.activeSelf)
            {
                fishesToRemove.Add(f);
                if (f.transform.parent.childCount < 0)
                {
                    Debug.Log("We dont have children");
                    f.transform.parent.gameObject.SetActive(false);
                }
            }
        }
        foreach (Follower f in fishesToRemove)
        {
            listOfFishes.Remove(f);
        }
        SelectNavArrowTarget();
    }
}
