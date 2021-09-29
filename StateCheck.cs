using UnityEngine;

namespace UnityStateManager
{
    public abstract class StateCheck : ScriptableObject
    {
        public virtual bool CheckState(StateManager manager)
        {
            return true;
        }
    }
}