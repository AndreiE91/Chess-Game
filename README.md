# Chess-Game

![GIF chess](Screenshots/chess_gif.gif)

## Description

This is a Chess Game implemented in C# using the Windows Presentation Foundation (WPF) framework. The game follows the standard rules of chess and provides a user-friendly interface for playing against another player locally.

<div style="display: grid; grid-template-columns: repeat(2, 1fr); gap: 20px;">
  <div style="display: flex; flex-direction: column; align-items: center;">

   <div style="margin-bottom: 10px;">
      <p style="text-align: center;">Starting Position</p>
      <img src="Screenshots/screenshot_start.png" alt="Starting Position" width="300">
   </div>

   <div style="margin-bottom: 10px;">
      <p style="text-align: center;">Checkmate</p>
      <img src="Screenshots/screenshot_mate.png" alt="Checkmate" width="300">
   </div>

 </div>

## Features

- Classic chess gameplay with standard rules.
- User-friendly interface built with WPF.
- Highlights legal moves for pieces when selected.
- Keeps track of game state, including check and checkmate conditions.
- All special rules included (En Passant, Fifty-Move Rule, Threefold Repetition).
- Sound effects for every interaction.
- Responsive design for different screen sizes.

<div style="display: flex; flex-direction: column; align-items: center;">

   <div style="margin-bottom: 10px;">
      <p style="text-align: center;">En Passant</p>
      <img src="Screenshots/screenshot_enpassant.png" alt="En Passant" width="300">
   </div>

   <div style="margin-bottom: 10px;">
      <p style="text-align: center;">Stalemate</p>
      <img src="Screenshots/screenshot_stalemate.png" alt="Stalemate" width="300">
   </div>

   <div style="margin-bottom: 10px;">
      <p style="text-align: center;">Pawn Promotion</p>
      <img src="Screenshots/screenshot_pawnqueen.png" alt="Pawn Promotion" width="300">
   </div>

</div>

## Getting Started

1. **Clone the repository:**
   ```bash
   git clone https://github.com/AndreiE91/Chess-Game.git
   ```

Open the solution file ChessGame.sln in Visual Studio.
Build the solution (Ctrl+Shift+B) to restore NuGet packages and build the project.
Start the application by running the project (F5).

## Usage

    Upon starting the application, the chessboard is displayed along with the pieces in their starting positions.
    Click on a piece to select it. Legal moves for the selected piece will be highlighted.
    Click on a highlighted square to move the selected piece there.
    The game ends when a player's king is in checkmate, or when players agree to a draw by pressing ESC and "RESTART".
    To start a new game, use the "RESTART" button in the ESC menu.

## Contributing

Contributions are welcome! If you'd like to contribute to this project, please follow these steps:

    1.Fork the repository.
    2.Create a new branch (git checkout -b feature/new-feature).
    3.Make your changes and commit them (git commit -am 'Add new feature').
    4.Push to the branch (git push origin feature/new-feature).
    5.Create a new Pull Request.

## Credits

This Chess Game project is maintained by AndreiE91.
