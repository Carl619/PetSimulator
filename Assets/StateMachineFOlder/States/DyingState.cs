using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingState : State
{
    public GameObject gameObject;

    public DyingState() : base()
    {
        StateAction = "Pet is too hungry or bored and is dying";
    }

    public override void Execute()
    {
        // Move our position a step closer to the target.
        var com = gameObject.GetComponent<HealthComponent>();
        var com2 = gameObject.GetComponent<HungerComponent>();
        var pet = gameObject.GetComponent<PetBehaviour>();
        if (com != null && com2 != null)
        {
            if (!com2.Eating)
            {
                com.LosingHealth();
            }
            //food is eaten
            if(pet != null)
			{
                pet.LookingForFood();
            }
        }
    }
}
