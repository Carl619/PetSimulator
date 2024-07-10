using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : State
{
    public float speed;
    public Transform transObj;
    public Vector3 Target;
    public int mul;

    public float cooldown;
    public float cooldownmax;

    public WanderState() : base()
    {
        mul = 5;
        Target = new Vector3(Random.value * mul, 1, Random.value * mul);
        cooldownmax = 3;
        cooldown = 0;
        StateAction = "Wander around the room";
        speed = 10;
    }

	public override void Execute()
	{
        // Move our position a step closer to the target.
        var step = speed * Time.deltaTime; // calculate distance to move
        cooldown += Time.deltaTime;
        if(cooldown >= cooldownmax)
		{
            Target = new Vector3(Random.value * mul, 1, Random.value * mul);
            cooldown = 0;
        }
        transObj.position = Vector3.MoveTowards(transObj.position, Target, step);
    }
}
