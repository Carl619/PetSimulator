using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection 
{

    public State BeginState;
    public State EndState;

    // Start is called before the first frame update

    public Connection(State beg, State end)
	{
        BeginState = beg;
        EndState = end;
	}
}
