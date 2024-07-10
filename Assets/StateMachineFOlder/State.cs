using System.Collections;
using System.Collections.Generic;

public class State
{
    public string StateAction;
    public Dictionary<string, Connection> Connections;
    // Start is called before the first frame update

    public State()
	{
        StateAction = "";
        Connections = new Dictionary<string, Connection>();
	}
    public void Enter()
	{

	}
    public virtual void Execute()
	{

	}
    public void Exit()
	{

	}
}
