using System.Collections.Generic;
using System;

namespace XNALara
{
    public class UndoHistory
    {
        private const int MaxHistorySize = 10000;

        private ControlGUI gui;

        private bool isEnabled;
        private LinkedList<UndoHistoryState> history;
        private UndoHistoryState lastState;

        private UndoHistoryStateInterrupt stateInterrupt;
        

        public UndoHistory(ControlGUI gui) {
            this.gui = gui;

            isEnabled = true;
            history = new LinkedList<UndoHistoryState>();
            lastState = null;

            stateInterrupt = new UndoHistoryStateInterrupt();
        }

        public void Clear() {
            history.Clear();
            lastState = null;
        }

        public void SaveState(UndoHistoryState state) {
            if (!isEnabled) {
                return;
            }
            bool isSignificant = true;
            if (lastState != null) {
                isSignificant = state.DetermineSignificance(lastState);
            }
            if (isSignificant) {
                history.AddLast(state);
                if (history.Count > MaxHistorySize) {
                    history.RemoveFirst();
                }
                //PrintUndoHistory();
            }
            lastState = state;
        }

        public void SaveInterrupt() {
            SaveState(stateInterrupt);
        }

        public void RestoreState() {
            while (true) {
                UndoHistoryState newState = RestoreStateInternal();
                if (newState == null) {
                    break;
                }
                if (newState is UndoHistoryStateBoneTransform) {
                    break;
                }
            }
            //PrintUndoHistory();
        }

        private UndoHistoryState RestoreStateInternal() {
            if (history.Count == 0) {
                return null;
            }

            UndoHistoryState state = history.Last.Value;
            history.RemoveLast();

            isEnabled = false;
            state.Apply(gui);
            isEnabled = true;

            lastState = (history.Count > 0 ? history.Last.Value : null);
            return state;
        }

        private void PrintUndoHistory() {
            foreach (UndoHistoryState state in history) {
                Console.WriteLine(state);
            }
            Console.WriteLine("----------------------------------------");
        }
    }
}
