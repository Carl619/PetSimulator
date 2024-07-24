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
        var petBehaviour = gameObject.GetComponent<PetBehaviour>();
        if (petBehaviour != null)
        {
            petBehaviour.LookingForFood();
        }
    }
}
