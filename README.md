# Conway's Game of Life

### Getting Started
To get started, run the program using:
```
dotnet run penta-decathlon.txt
``` 

To load an initial state from a text file, run the program as follows:
```
dotnet run <filepath>
``` 

To create your own initial state, make a new txt file using **@** or **#** to denote alive cells, and any other character can be used to denote a dead cell.

To change the character used to render alive cells, enter it as an argument after the filepath.
```
dotnet run <filepath> <char>
```

### Control
The console application features keyboard controls to play, pause and reset the animation.

**Spacebar**: Play/Pause  
**R**: Reset Animation  
**Esc**: Exit Program