using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungryState : State
{
    
    public GameObject gameObject;
    public Transform transObj;

    public HungryState() : base()
    {
        StateAction = "Pet is hungry or bored";
    }

    public override void Execute()
    {
        var com = gameObject.GetComponent<PetBehaviour>();
        if (com != null)
        {
            com.LookingForFood();
        }
    }
}
