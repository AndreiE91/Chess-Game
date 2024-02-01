using ChessLogic;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace ChessUI {
    /// <summary>
    /// Interaction logic for PromotionMenu.xaml
    /// </summary>
    public partial class PromotionMenu : UserControl {

        public event Action<PieceType> PieceSelected;

        public PromotionMenu(Player player) {
            InitializeComponent();

            QueenImg.Source = Images.GetImage(player, PieceType.Queen);
            RookImg.Source = Images.GetImage(player, PieceType.Rook);
            KnightImg.Source = Images.GetImage(player, PieceType.Knight);
            BishopImg.Source = Images.GetImage(player, PieceType.Bishop);
        }

        private void QueenImg_MouseDown(object sender, MouseButtonEventArgs e) {
            PieceSelected?.Invoke(PieceType.Queen);
            SoundFX.PlaySound("PawnQueen");
        }

        private void RookImg_MouseDown(object sender, MouseButtonEventArgs e) {
            PieceSelected?.Invoke(PieceType.Rook);
            SoundFX.PlaySound("PawnQueen");
        }

        private void BishopImg_MouseDown(object sender, MouseButtonEventArgs e) {
            PieceSelected?.Invoke(PieceType.Bishop);
            SoundFX.PlaySound("PawnQueen");
        }

        private void KnightImg_MouseDown(object sender, MouseButtonEventArgs e) {
            PieceSelected?.Invoke(PieceType.Knight);
            SoundFX.PlaySound("PawnQueen");
        }
    }
}
