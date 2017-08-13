using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// If you're C# 5.0 or older, 
using static UndoRedo.History;
using static System.Console;

namespace UndoRedo
{
    class Program
    {
        /// <summary>
        /// Undo/Redo example.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            /// Simple Undo/Redo example.
            WriteLine("Simple undo/redo example.");
            int x = 0;
            WriteLine($"{nameof(x)} is {x}.");

            // Use lambda expression to record your action.
            // Make sure that undo action is correct scheme.
            // If not, it results in an invalid status after you execute "Undo()."

            // Increment x by 1
            Record(() => { x++; }, () => { x--; });
            WriteLine($"{nameof(x)} is {x}.");

            // Undo the last action (means decrement x by 1)
            Undo();
            WriteLine($"{nameof(x)} is {x}.");

            // Cannot execute undo when you're at the first state.
            Undo();
            WriteLine($"{nameof(x)} is {x}.");

            // Redo the action (means increment x by 1)
            Redo();
            WriteLine($"{nameof(x)} is {x}.");

            // Cannot execute redo when you at the last state.
            Redo();
            WriteLine($"{nameof(x)} is {x}.");


            /// Transaction example
            // Transaction packs multiple actions into one command.

            // Record all commands between "BeginTransaction()" and "EndTransaction()",
            WriteLine();
            WriteLine("Simple transaction command.");
            WriteLine($"{nameof(x)} is {x}.");
            BeginTransaction();
            Record(() => { x += 10; }, () => { x -= 10; });
            Record(() => { x *= 10; }, () => { x /= 10; });
            Record(() => { x -= 120; }, () => { x += 120; });
            EndTransaction();
            WriteLine($"{nameof(x)} is {x}.");
            Undo();
            WriteLine($"{nameof(x)} is {x}.");
            Redo();
            WriteLine($"{nameof(x)} is {x}.");

            ReadKey();
        }
    }
}