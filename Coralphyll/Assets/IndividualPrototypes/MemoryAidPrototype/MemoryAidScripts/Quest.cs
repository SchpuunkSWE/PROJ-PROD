using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//Quest class that will enherit from a Scriptable object 
public class Quest : ScriptableObject
{
    // Opened in  the editor will added information about the quest ?? <-- she said so in the video, dont know
    [System.Serializable]

    //A structure of the info about the Quest that will have a name, Icon and description
    public struct Info
    {
        public string Name;
        public Sprite Icon;
        public string Describtion;
    }
    // A field for the Information  
    [Header("Info")] public Info Information;


    // A structure for the reward we get when we finish a Quest
    [System.Serializable]
    public struct Stat
    {
        public int currency;
        public int xp;
    }
    // A field for the reward when we finish the quest
    [Header("Reward")] public Stat Reward = new Stat { currency = 10, xp = 10 };



    public bool Completed { get; protected set; }
    public QuestCompletedEvent QuestCompleted;




    //Creating a Quest goals which is an abstract class inside the quest class
    public abstract class QuestGoal : ScriptableObject
    {

        //the class have things that are needed to complete the goal and they are protected
        //because we don't wan't anyone outside this class to set it's value
        protected string Description;
        public int CurrentAmount { get; protected set; }
        public int RequiredAmount = 1;

        //The reason we create these fields is because no matter what type of goal it is
        // it always have a number of things we need to do
        // if it is a building goal, we set the amount to 1 , if it is a gathering goal, we set the amount to ex 3.


        public bool Completed { get; protected set; }
        [HideInInspector] public UnityEvent GoalCompleted;



        //We will also creating a virtual void to collect the describtion

        public virtual string GetDescription()
        {
            return Description;
        }


        public virtual void Initialize()
        {
            Completed = false;
            GoalCompleted = new UnityEvent();
        }

        protected void Evaluate()
        {
            if(CurrentAmount >= RequiredAmount)
            {
                Complete();
            }

        }

        private void Complete()
        {
            Completed = true;
            GoalCompleted.Invoke();
            GoalCompleted.RemoveAllListeners();
        }

        public void Skip()
        {
            //Charge the player some currency?? based on the structure of our game
            Complete();
        }


    }

    //Created a list of Goals

    public List<QuestGoal> Goals;

    
    public void Initialize()
    {
        Completed = false;
        QuestCompleted = new QuestCompletedEvent();

        foreach (var goal in Goals)
        {
            goal.Initialize();
            goal.GoalCompleted.AddListener(delegate { CheckGoals(); });


        }
    }

    private void CheckGoals()
    {
        //Check if all the goals in the quest is completed and if so give the player their reward
        Completed = Goals.TrueForAll(g => g.Completed);
        if (Completed)
        {
            //give reward
            QuestCompleted.Invoke(this);
            QuestCompleted.RemoveAllListeners();
        }
    }

}

public class QuestCompletedEvent : UnityEvent<Quest> { }