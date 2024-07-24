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
        var healthCom = gameObject.GetComponent<HealthComponent>();
        var hungerCom = gameObject.GetComponent<HungerComponent>();
        var petBehaviour = gameObject.GetComponent<PetBehaviour>();
        if (healthCom != null && hungerCom != null)
        {
            if (!hungerCom.Eating)
            {
                healthCom.LosingHealth();
            }
            //food is eaten
            if(petBehaviour != null)
			{
                petBehaviour.LookingForFood();
            }
        }
    }
}
