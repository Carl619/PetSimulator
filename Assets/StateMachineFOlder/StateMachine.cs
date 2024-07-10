using System.Collections;
using System.Collections.Generic;

public class StateMachine 
{
    public List<State> States;
    public State CurrentState;
    // Start is called before the first frame update

    public StateMachine()
	{
        States = new List<State>();
	}

    public void init()
	{
        WanderState wander = new WanderState();
        HungryState hungry = new HungryState();
        DyingState dying = new DyingState();

        wander.Connections.Add("hungry", new Connection(wander, hungry));
        hungry.Connections.Add("fine", new Connection(hungry, wander));
        hungry.Connections.Add("dying", new Connection(hungry, dying));
        dying.Connections.Add("fine", new Connection(dying, wander));

        States.Add(wander);
        States.Add(hungry);
        States.Add(dying);

        CurrentState = States[0];
    }

    public void Execute()
	{
        UIManager.Instance.StatePet.text = CurrentState.StateAction;
        CurrentState.Execute();
    }

    public void OnDying()
	{
        if (CurrentState.Connections.ContainsKey("dying"))
        {
            var state = CurrentState.Connections["dying"];
            if (state != null)
            {
                CurrentState = state.EndState;
            }
        }
    }

    public void OnHungry()
    {
        if (CurrentState.Connections.ContainsKey("hungry"))
        { 
            var state = CurrentState.Connections["hungry"];
            if (state != null)
            {
                CurrentState = state.EndState;
            }
        }
    }

    public void OnFine()
    {
        if (CurrentState.Connections.ContainsKey("fine"))
        {
            var state = CurrentState.Connections["fine"];
            if (state != null)
            {
                CurrentState = state.EndState;
            }
        }
    }
}
