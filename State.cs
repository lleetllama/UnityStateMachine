using System.Security.AccessControl;
using UnityEngine;

namespace UnityStateManager
{
    public class State : ScriptableObject
    {
        public string debugName;
        public StateAction[] entryActions, stateActions, exitActions;
        public StateTransition[] stateTransitions;

        public virtual void DoActions(StateAction[] actionArray, StateManager stateManager)
        {
            for (int i = 0; i < actionArray.Length; i++)
            {
                if (actionArray[i] == null)
                    continue;

                actionArray[i].DoAction(stateManager);
            }
        }

        public virtual void OnStateEnter(StateManager stateManager, StateTransition transition)
        {
            DoActions(entryActions, stateManager);
        }

        public virtual void OnStateTick(StateManager stateManager)
        {
            DoStateLogic(stateManager);
            DoActions(stateActions, stateManager);
        }

        // old state exits first, then new state enters.
        public virtual void OnStateExit(StateManager stateManager, StateTransition transition)
        {
            DoActions(exitActions, stateManager);

        }

        public virtual void DoStateLogic(StateManager stateManager)
        {
            for (int i = 0; i < stateTransitions.Length; i++)
            {
                StateTransition transition = stateTransitions[i];

                bool validConcern = transition.condition.CheckState(stateManager);

                if (validConcern && transition.trueState != this)
                {
                    // Debug.Log("I am moving to state:" + transition.trueState.debuggingName);
                    stateManager.UpdateState(transition.trueState, transition);
                    return;
                }
                else if (!validConcern && transition.falseState != this)
                {
                    // Debug.Log("I am moving to state:" + transition.falseState.debuggingName);
                    stateManager.UpdateState(transition.falseState, transition);
                    return;
                }
                else
                {
                    // Debug.Log("I am staying in state:" + this.debuggingName);
                }
            }
        }

    }
}