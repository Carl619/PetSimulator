using UnityEngine;

public class AIComponent : MonoBehaviour
{
    public StateMachine Machine;
    // Start is called before the first frame update
    void Start()
    {
        Machine = new StateMachine();
        Machine.init();
        var wan = (WanderState)Machine.States[0];
        wan.transObj = transform;
        var hun = (HungryState)Machine.States[1];
        hun.transObj = transform;
        hun.gameObject = gameObject;
        var dyi = (DyingState)Machine.States[2];
        dyi.gameObject = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Machine.Execute();
    }
}
