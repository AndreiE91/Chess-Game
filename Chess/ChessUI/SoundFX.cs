using System;
using System.Collections.Generic;
using System.Media;

namespace ChessUI {
    public static class SoundFX {
        private static readonly Dictionary<string, SoundPlayer> soundPlayers = new Dictionary<string, SoundPlayer>();

        static SoundFX() {
            LoadSound("ButtonClick", "SFX/buttonClick.wav");
            LoadSound("PieceCapture", "SFX/capture.wav");
            LoadSound("PieceMove", "SFX/move.wav");
            LoadSound("PawnQueen", "SFX/pawnQueen.wav");
            LoadSound("GameOver", "SFX/gameOver.wav");
            LoadSound("Restart", "SFX/restart.wav");
            LoadSound("Check", "SFX/kingCheck.wav");
            LoadSound("PieceSelect", "SFX/pieceSelect.wav");
            LoadSound("MenuPopup", "SFX/menuPopup.wav");
        }

        private static void LoadSound(string soundName, string filePath) {
            soundPlayers[soundName] = new SoundPlayer(filePath);
        }

        public static void PlaySound(string soundName) {
            if (soundPlayers.TryGetValue(soundName, out SoundPlayer player)) {
                try {
                    player.Play();
                }
                catch (Exception ex) {
                    Console.WriteLine("Error playing sound: " + ex.Message);
                }
            }
            else {
                Console.WriteLine("Sound not found: " + soundName);
            }
        }
    }
}
