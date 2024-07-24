using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Text HealthMeter;
    public Text HappinessMeter;
    public Text HungerMeter;

    public Image HealthBar;
    public Image HappinessBar;
    public Image HungerBar;

    public Text StatePet;
    public float Happinesss;
    public float Health;
    public float Hunger;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        HappinessMeter.text = "Happiness: ";
        HealthMeter.text = "Health: ";
        HungerMeter.text = "Hunger: ";
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.fillAmount = Health / 100;
        HappinessBar.fillAmount = Happinesss / 100;
        HungerBar.fillAmount = Hunger / 100;
    }
}
