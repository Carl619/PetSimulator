using UnityEngine;
using UnityEngine.SceneManagement;

public class PetBehaviour : MonoBehaviour
{
	public GameObject Food;
	public delegate void PetEvent();
	public PetEvent DyingEvent;
	public PetEvent EatingEvent;
	public PetEvent HungryEvent;
	public PetEvent FineEvent;
	public GameObject FoodPrefab;

	private bool Initialized;
	// Start is called before the first frame update
	void Start()
	{
		Initialized = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (!Initialized)
		{
			SetEvents();
		}

		var hungerCom = gameObject.GetComponent<HungerComponent>();
		var happyCom = gameObject.GetComponent<HappinessComponent>();

		Death();

		if (hungerCom.Dying || happyCom.Dying)
		{
			DyingEvent?.Invoke();
		}
		else if (hungerCom.Hungry || happyCom.Bored)
		{
			HungryEvent?.Invoke();
		}
		else if (!hungerCom.Hungry && !happyCom.Bored)
		{
			FineEvent?.Invoke();
		}
	}

	public void Death()
	{
		var healthCom = gameObject.GetComponent<HealthComponent>();
		if (healthCom != null)
		{
			if (healthCom.Health == 0)
			{
				SceneManager.LoadScene("GameOver");
			}
		}
	}

	private void SetEvents()
	{
		var aiCom = GetComponent<AIComponent>();
		if (aiCom != null)
		{
			DyingEvent += aiCom.Machine.OnDying;
			EatingEvent += aiCom.Machine.OnHungry;
			FineEvent += aiCom.Machine.OnFine;
			HungryEvent += aiCom.Machine.OnHungry;
		}

		Initialized = true;
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
		var healthCom = gameObject.GetComponent<HealthComponent>();
		if (healthCom != null)
		{
			healthCom.AddHealth(heal);
		}
	}
	public void LookingForFood()
	{
		if (Food == null)
		{
			var hungerCom = gameObject.GetComponent<HungerComponent>();
			if (hungerCom != null)
			{
				hungerCom.Eating = false;
			}

			var healthCom = gameObject.GetComponent<HealthComponent>();
			if (healthCom != null)
			{
				healthCom.Healing = false;
			}
			Food = GameObject.Find("Food");
		}

		if (Food != null)
		{
			var foodBehaviour = Food.GetComponent<FoodBehaviour>();

			if (foodBehaviour != null)
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
		var hungerCom = gameObject.GetComponent<HungerComponent>();
		if (hungerCom != null)
		{
			hungerCom.Eating = true;
		}

		var healthCom = gameObject.GetComponent<HealthComponent>();
		if (healthCom != null)
		{
			healthCom.Healing = true;
		}
	}
}
