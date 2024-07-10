using UnityEngine;

public class HungerComponent : MonoBehaviour
{
    public float Hunger;
    public float HungerMax;
    public float PercentAdded;

    public float Cooldown;
    public float CooldownMax;

    public bool Hungry;
    public bool Dying;
    public bool Eating;
    // Start is called before the first frame update
    void Start()
    {
        Hunger = 0;
        HungerMax = 100;
        PercentAdded = 5;

        Cooldown = 0;
        CooldownMax = 5;

        Hungry = false;
        Dying = false;
        Eating = false;
    }

    // Update is called once per frame
    void Update()
    {
        UIManager.Instance.Hunger = Hunger;
        Cooldown += Time.deltaTime;
        if(Cooldown >= CooldownMax)
		{

            if(Eating)
			{
                Eat();
			}
			else
            {
                HungerLoop();
            }
            Cooldown = 0;
        }
        if(!Hungry)
		{
            Eating = false;
		}

        if(Hunger > 80 && Hunger < HungerMax)
		{
            Hungry = true;
        }
        else if(Hunger == HungerMax)
		{
            Dying = true;
        }
        else if (Hunger >= 20 && Hunger < 50)
        {
            Dying = false;
        }
        else if(Hunger < 20)
		{
            Hungry = false;
        }
    }

    void HungerLoop()
	{
        Hunger += PercentAdded;

        if (Hunger > HungerMax)
        {
            Hunger = HungerMax;
        }
    }

    void Eat()
	{
        Hunger -= PercentAdded;

        if(Hunger < 0)
		{
            Hunger = 0;
		}
	}
}
