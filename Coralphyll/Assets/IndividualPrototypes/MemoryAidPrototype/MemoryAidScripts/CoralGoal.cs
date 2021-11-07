using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralGoal : Quest.QuestGoal
{
    public string Coral;

    public override string GetDescription()
    {
        return $"Fulfill the need of {Coral}";

    }

}
