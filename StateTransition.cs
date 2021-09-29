namespace UnityStateManager
{
    [System.Serializable]
    public class StateTransition
    {
        public StateCheck condition;
        public State trueState;
        public State falseState;
    }
}