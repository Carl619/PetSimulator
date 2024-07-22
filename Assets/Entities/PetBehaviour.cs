using UnityEngine;
using UnityEngine.SceneManagement;

public class PetBehaviour : MonoBehaviour
{
    public GameObject Food;
    public delegate void PetEvent();
    public PetEvent dyingEvent;
    public PetEvent eatingEvent;
    public PetEvent hungryEvent;
    public PetEvent fineEvent;
    public GameObject FoodPrefab;

    bool initialized;
    // Start is called before the first frame update
    void Start()
    {
        initialized = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!initialized)
		{
            SetEvents();
        }

        var hun = gameObject.GetComponent<HungerComponent>();
        var hap = gameObject.GetComponent<HappinessComponent>();

        Death();

        if (hun.Dying || hap.Dying)
        {
            dyingEvent?.Invoke();
        }
        else if(hun.Hungry || hap.Bored)
        {
            hungryEvent?.Invoke();
        }
        else if (!hun.Hungry && !hap.Bored)
        {
            fineEvent?.Invoke();
        }
    }

    public void Death()
	{
        var com = gameObject.GetComponent<HealthComponent>();
        if (com != null)
        {
            if(com.Health == 0)
			{
                SceneManager.LoadScene("GameOver");
            }
        }
        
    }

    private void SetEvents()
	{
        var com = GetComponent<AIComponent>();
        if(com != null)
		{
            dyingEvent += com.Machine.OnDying;
            eatingEvent += com.Machine.OnHungry;
            fineEvent += com.Machine.OnFine;
            hungryEvent += com.Machine.OnHungry;
        }

        initialized = true;
    }

    public void CreateFood()
	{
        Food = GameObject.Find("Food");
        if (Food == null)
        {
            Instantiate(FoodPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

    public void Cure(float heal)
    {
        var com = gameObject.GetComponent<HealthComponent>();
        if (com != null)
        {
            com.AddHealth(heal);
        }
    }
    public void LookingForFood()
	{
        if (Food == null)
        {
            var com = gameObject.GetComponent<HungerComponent>();
            if (com != null)
            {
                com.Eating = false;
            }

            var com2 = gameObject.GetComponent<HealthComponent>();
            if (com2 != null)
            {
                com2.Healing = false;
            }
            Food = GameObject.Find("Food");
        }

        if (Food != null)
        {
            var com = Food.GetComponent<FoodBehaviour>();

            if (com != null)
            {
                Move(5);
                var distanceBetweenObjects = Vector3.Distance(transform.position, Food.transform.position);
                if (distanceBetweenObjects < 1)
                {
                    Eat();
                }
            }
        }
    }

    private void Move(float speed)
    {
        Quaternion lookRotation;
        Vector3 direction;
        var step = speed * Time.deltaTime;
        direction = (Food.transform.position - transform.position).normalized;
        lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);
        transform.position = Vector3.MoveTowards(transform.position, Food.transform.position, step);
    }

    private void Eat()
    {
        var com = gameObject.GetComponent<HungerComponent>();
        if (com != null)
        {
            com.Eating = true;
        }

        var com2 = gameObject.GetComponent<HealthComponent>();
        if (com2 != null)
        {
            com2.Healing = true;
        }
    }
}
