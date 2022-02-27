# Tetris-Project

This is my attempt at recreating the classic game Tetris. 
This project is part of the FutureGames course "Mobile Game Design".

You can try it out at: https://play.unity.com/mg/other/final_build

## Documentation

Structure of the project:

    1. Starter:
        The starter file's method runs on the first scene load. It creates a Manager Object that has an 
        instance of Load manager and the Event System.
    2. Load Manager:
        This is responsible for loading all the scenes in the game. For every scene:
            1. Enables the loading screen
            2. Unloads any scenes that are not needed.
            3. Loads the specified scene.
            4. Calls a setup function in the scene's manager (if applicable).
    3. Game Manager:
        This keeps track of the end game state, score, and high scores.
    4. Specific Screen Managers: 
        These contain methods for the UI buttons and score field updates.
    5. Spawn Manager:
        This spawns blocker and power up tetrominoes at random positions. This contains a method to 
        spawn a random regular tetromino at the top of the board.
    6. TetrisGrid:
        This creates the grid for the board. It takes care of checking if rows are full, clearing 
        them, and shifting rows down.
    7. Tetromino:
        This is responsible for the valid movement of the tetromino, updating the tetromino's position
        in the grid, and spawning a new tetromino when it lands.
    8. GridBlock:
        This spawns a block for each grid position so that the player can easily see the grid.
    9. UI button:
        This is a custom button script that is used throughout the project.

