using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStateManager
{
    public abstract class StateAction : ScriptableObject
    {
        public virtual void DoAction(StateManager stateManager)
        {

        }
    }
}