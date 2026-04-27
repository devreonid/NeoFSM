using System.Collections.Generic;

namespace NeoFSM
{
    public enum State { S, A, B, C }

    public class FsmEngine
    {
        public State CurrentState { get; private set; }
        public List<State> History { get; private set; }

        public FsmEngine() => Reset();

        public void Reset()
        {
            CurrentState = State.S;
            History = new List<State> { State.S };
        }

        public bool Validate(string input)
        {
            Reset();
            foreach (char c in input)
            {
                if (c == '0') Transition0();
                else if (c == '1') Transition1();
                else { CurrentState = State.C; } // Invalid char

                History.Add(CurrentState);
            }
            return CurrentState == State.B;
        }

        private void Transition0()
        {
            CurrentState = CurrentState switch
            {
                State.S => State.A,
                State.A => State.C,
                State.B => State.A,
                _ => State.C
            };
        }

        private void Transition1()
        {
            CurrentState = CurrentState switch
            {
                State.S => State.B,
                State.A => State.B,
                State.B => State.B,
                _ => State.C
            };
        }
    }
}