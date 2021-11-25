using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
   public List <TabButton> tabButtons;
   public List <GameObject> objectsToSwap;
   public Sprite tabIdle;
   public Sprite tabHovered;
   public Sprite tabSelected;
   public TabButton selectedTab;
   public TabButton startButton;

   void Start(){
       OnTabSelected(startButton);
       
   }

   public void Subscribe (TabButton button){
       if(tabButtons == null)
       {
           tabButtons = new List<TabButton> ();


       }
       tabButtons.Add(button);
   }

   public void OnTabEnter(TabButton button)
   {
       ResetTabs();
       if (selectedTab== null || button != selectedTab )
       {
           button.background.sprite = tabHovered;
        }
       

   }
   public void OnTabExit(TabButton button )
   {
       ResetTabs();
       
       
   }

   public void OnTabSelected(TabButton button)
   {
       selectedTab = button;
       ResetTabs();
       button.background.sprite = tabSelected;
       int index = button.transform.GetSiblingIndex();
       for(int i=0; i<objectsToSwap.Count; i++)
       {
           if(i == index)
           {
               objectsToSwap[i].SetActive(true);
           } else 
            { 
                objectsToSwap[i].SetActive(false);

           }

       }
   }

   public void ResetTabs()
   {
       foreach(TabButton button in tabButtons)
       {
           if(selectedTab != null && button == selectedTab) {continue;}
           button.background.sprite = tabIdle;

       }
   }
  
}
