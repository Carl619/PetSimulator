using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBehaviour : MonoBehaviour
{
    public float Cooldown;
    public float CooldownMax;
    public float Durability;
    // Start is called before the first frame update
    void Start()
    {
        Durability = 100;
        Cooldown = 0;
        CooldownMax = 3;

        gameObject.name = "Food";
    }

    // Update is called once per frame
    void Update()
    {
        Cooldown += Time.deltaTime;
        if (Cooldown >= CooldownMax)
        {
            Durability -= 5;
            if(Durability <= 0)
			{
                Destroy(gameObject);
			}
            Cooldown = 0;
        }
    }
}
