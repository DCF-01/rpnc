using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core.Memento
{
    public class MementoCaretaker
    {
        private static Stack<DataContextMemento> _undoStack = new();
        private static Stack<DataContextMemento> _redoStack = new();
        
        public static DataContextMemento Redo()
        {
            if (_redoStack.Count > 0)
            {
                var el = _redoStack.Pop();
                _undoStack.Push(el);

                _redoStack.TryPeek(out var res);
                return res;
            }
            else
            {
                return null;
            }
        }

        public static DataContextMemento Undo()
        {
            if (_undoStack.Count > 0)
            {
                var el = _undoStack.Pop();
                _redoStack.Push(el);

                _undoStack.TryPeek(out var res);
                return res;
            }
            else
            {
                return null;
            }
        }

        public static void PushToStack(DataContext currentContext)
        {
            if(currentContext != null)
            {
                _undoStack.Push(currentContext.Save());
            }
        }

        public static void Reset()
        {
            _undoStack = new();
            _redoStack = new();
        }

    }
}
