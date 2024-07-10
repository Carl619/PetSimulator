using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public float Health;
    public float HealthMax;
    public float PercentLost;

    public float Cooldown;
    public float CooldownMax;

    public bool Dying;
    public bool Healing;
    // Start is called before the first frame update
    void Start()
    {
        HealthMax = 100;
        Health = 80;
        PercentLost = 5;

        Dying = false;

        Cooldown = 0;
        CooldownMax = 5;
    }

    // Update is called once per frame
    void Update()
    {
        UIManager.Instance.Health = Health;

        Cooldown += Time.deltaTime;
        if (Cooldown >= CooldownMax)
        {
            if (Healing)
            {
                Cure();
            }
            Cooldown = 0;
        }
    }

    public void LosingHealth()
    {
        Cooldown += Time.deltaTime;
        if (Cooldown >= CooldownMax)
        {
            Health -= PercentLost;

            if (Health < 0)
            {
                Health = 0;
            }
            Cooldown = 0;
        }
    }

    public void AddHealth(float heal)
    {
        Health += heal;

        if (Health > HealthMax)
        {
            Health = HealthMax;
        }
    }

    public void Cure()
	{
        Health += PercentLost;

        if (Health > HealthMax)
        {
            Health = HealthMax;
        }
    }
}
