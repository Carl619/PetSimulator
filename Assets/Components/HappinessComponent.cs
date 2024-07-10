using UnityEngine;

public class HappinessComponent : MonoBehaviour
{
    public float Happiness;
    public float HappinessMax;
    public float PercentLost;

    public float Cooldown;
    public float CooldownMax;

    public bool Dying;
    public bool Bored;
    // Start is called before the first frame update
    void Start()
    {
        HappinessMax = 100;
        Happiness = HappinessMax;
        PercentLost = 5;

        Dying = false;
        Bored = false;

        Cooldown = 0;
        CooldownMax = 5;
    }

    // Update is called once per frame
    void Update()
    {
        UIManager.Instance.Happinesss = Happiness;

        LosingHappiness();

        if (Happiness < 20 && Happiness > 0)
        {
            Bored = true;
        }
        else if (Happiness == 0)
        {
            Dying = true;
        }
        else if (Happiness < 80 && Happiness > 50)
        {
            Dying = false;
        }
        else if (Happiness > 80)
        {
            Bored = false;
        }
    }

    public void LosingHappiness()
    {
        Cooldown += Time.deltaTime;
        if (Cooldown >= CooldownMax)
        {
            Happiness -= PercentLost;

            if (Happiness < 0)
            {
                Happiness = 0;
            }
            Cooldown = 0;
        }
    }

    public void AddHappiness(float heal)
    {
        Happiness += heal;

        if (Happiness > HappinessMax)
        {
            Happiness = HappinessMax;
        }
    }

    public void Pet()
    {
        Happiness += PercentLost;

        if (Happiness > HappinessMax)
        {
            Happiness = HappinessMax;
        }
    }
}
