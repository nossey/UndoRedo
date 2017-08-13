# UndoRedo
This project produces a simple undo/redo functions.

## Getting Started
Just download "History.cs."<br>
If you're interested in a sample code, pull this repository.

### Prerequisites
.NET Framework(C#) is needed.

### Installing
It's so easy.<br>
Just add "History.cs" file to your own project and declare following statement.

```CSharp
// C# 6.0 or later
using static UndoRedo.History;

// C# 5.0 or older
using UndoRedo;
```

## How to use & examples
Same example is shown in "Program.cs."

### Single operation
When you execute undoable/redoable action, call "Record" method with arguments of lambda expressions.
```CSharp
History.Record(()=>{ /*Do*/ }, ()=>{ /*Undo*/ });
```

In this example, we operate an integer value and test undo/redo.

```CSharp
using static UndoRedo.History;
using static System.Console;

...

int x = 0;
WriteLine($"{nameof(x)} is {x}.");

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
```

And it results in following output.
```bash
x is 0.
x is 1.
x is 0.
Invalid operation.
x is 0.
x is 1.
Invalid operation.
x is 1.
```

### Transaction operation
History.cs also supports a transaction, which packs multiple actions into one action.

```CSharp
History.BeginTransaction();
History.Record(()=>{ /*Do A*/ }, ()=>{ /*Undo A*/ });
History.Record(()=>{ /*Do B*/ }, ()=>{ /*Undo B*/ });
...
History.EndTransaction();
```

We operate an integer value for several times between "BeginTransaction()" and "EndTransaction()", and test undo/redo.

```CSharp
using static UndoRedo.History;
using static System.Console;

...

int x = 1;
WriteLine($"{nameof(x)} is {x}.");

// Record all actions between "BeginTransaction()" and "EndTransaction()."
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
```

And it results in following output.
```bash
x is 1.
x is -10.
x is 1.
x is -10.
```

## Author
nossey

## License
It's totally free for use.<br>
But please don't disguise copyright :(
