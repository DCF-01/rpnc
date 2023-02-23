using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core.Memento
{
    //Singleton
    public class MementoCaretaker
    {
        private static object _lock = new object();
        private static MementoCaretaker _instance;
        private Stack<DataContextMemento> _undoStack = new();
        private Stack<DataContextMemento> _redoStack = new();

        private MementoCaretaker()
        {

        }

        public DataContextMemento Redo()
        {
            if (_redoStack.Count > 0)
            {
                var el = _redoStack.Pop();
                _undoStack.Push(el);

                _redoStack.TryPeek(out var res);
                return res ?? el;
            }
            else
            {
                return null;
            }
        }

        public DataContextMemento Undo()
        {
            if (_undoStack.Count > 0)
            {
                var el = _undoStack.Pop();
                _redoStack.Push(el);

                _undoStack.TryPeek(out var res);
                return res ?? el;
            }
            else
            {
                return null;
            }
        }

        public void PushToStack(DataContext currentContext)
        {
            if (currentContext != null)
            {
                _undoStack.Push(currentContext.Save());
            }
        }

        public static void Reset()
        {
            _instance = new MementoCaretaker();
        }

        public void ResetRedo()
        {
            _redoStack = new();
        }

        public static MementoCaretaker GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new MementoCaretaker();
                        return _instance;
                    }
                }
            }

            return _instance;
        }

    }
}
