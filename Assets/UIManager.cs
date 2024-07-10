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
        HappinessMeter.text = "Happiness: " + Happinesss.ToString();
        HealthMeter.text = "Health: " + Health.ToString();
        HungerMeter.text = "Hunger: " + Hunger.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        HappinessMeter.text = "Happiness: " + Happinesss.ToString();
        HealthMeter.text = "Health: " + Health.ToString();
        HungerMeter.text = "Hunger: " + Hunger.ToString();
    }
}
