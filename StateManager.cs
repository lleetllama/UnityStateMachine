using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStateManager
{
    public abstract class StateManager : MonoBehaviour
    {

        [SerializeField]
        State currentState, defaultState;

        public float stateTickCounter; // how long we have been in state

        public void StateManagerTick()
        {
            if (currentState == null)
                currentState = defaultState;

            currentState.OnStateTick(this);
            stateTickCounter += Mathf.Round(Time.deltaTime * 100f);
        }

        public void UpdateState(State newState, StateTransition transition)
        {
            if (currentState == newState || newState == null)
                return;

            if (currentState != null)
                currentState.OnStateExit(this, transition);

            newState.OnStateEnter(this, transition);
            currentState = newState;
            stateTickCounter = 0;
        }
    }
}

