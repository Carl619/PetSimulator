using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : State
{
    public float speed;
    public Transform transObj;
    public Vector3 Target;
    public int mul;

    public float Cooldown;
    public float Cooldownmax;

    private Quaternion LookRotation;
    private Vector3 Direction;

    public WanderState() : base()
    {
        mul = 5;
        Target = new Vector3(Random.value * mul, 0, Random.value * mul);
        Cooldownmax = 3;
        Cooldown = 0;
        StateAction = "Wander around the room";
        speed = 10;
    }

	public override void Execute()
	{
        // Move our position a step closer to the target.
        var step = speed * Time.deltaTime; // calculate distance to move
        Cooldown += Time.deltaTime;
        if(Cooldown >= Cooldownmax)
		{
            Target = new Vector3(Random.value * mul, 0, Random.value * mul);
            Cooldown = 0;
        }

        Direction = (Target - transObj.position).normalized;
        LookRotation = Quaternion.LookRotation(Direction);
        transObj.rotation = Quaternion.Slerp(transObj.rotation, LookRotation, Time.deltaTime * speed);
        transObj.position = Vector3.MoveTowards(transObj.position, Target, step);
    }
}
