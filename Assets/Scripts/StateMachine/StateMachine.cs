using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{

    public List<State> states = new List<State>();
    public State CurrentState = null;

    public void SwitchState<aState>()
    {
        foreach (State s in states)
        {
            if (s.GetType() == typeof(aState))
            {
                CurrentState?.ExitState();
                CurrentState = s;
                CurrentState.EnterState();
                Debug.Log("switch state to" + CurrentState.ToString());
                return;
            }
        }
        Debug.LogWarning("State does not exist");
    }

    public virtual void UpdateStateMachine()
    {
        CurrentState?.UpdateState();
    }
}