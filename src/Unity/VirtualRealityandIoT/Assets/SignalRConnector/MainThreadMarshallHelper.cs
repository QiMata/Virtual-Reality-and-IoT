using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.SignalRConnector
{
    class MainThreadMarshallHelper
    {
        private Queue<Action> _actions;

        public MainThreadMarshallHelper()
        {
            _actions = new Queue<Action>();
        }

        public void MarshallToMainThread(Action action)
        {
            lock (_actions)
            {
                _actions.Enqueue(action);
            }
        }

        public void OnMainThread()
        {
            lock (_actions)
            {
                foreach (var action in _actions)
                {
                    action();
                }
            }
        }
    }
}
