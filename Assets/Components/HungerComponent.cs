using UnityEngine;

public class HungerComponent : MonoBehaviour
{
    public float Hunger;
    public const float HungerMax = 100;
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

        switch (Hunger)
        {
            case HungerMax:
                Hungry = true;
                break;
            case > 80:
                Hungry = false;
                break;
            case < 20:
                Hungry = true;
                break;
            case < 50:
                Hungry = false;
                break;
            default:
                break;
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
