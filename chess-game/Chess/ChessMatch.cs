using System;

using ChessGame.Board;

namespace ChessGame.Chess
{
    class ChessMatch
    {
        public ChessBoard ChessBoard { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }

        public ChessMatch ()
        {
            ChessBoard = new ChessBoard();
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;

            PlacePieces();
        }

        public void ExecuteMovement (ChessPosition origin, ChessPosition target)
        {
            var originPiece = ChessBoard.RemovePiece(origin.ToPosition());
            var removedPiece = ChessBoard.RemovePiece(target.ToPosition());

            ChessBoard.PutPiece(originPiece, target.ToPosition());
            
            originPiece.IncrementMoviments();
        }

        private void PlacePieces ()
        {
            // White's pieces
            ChessBoard.PutPiece(new Tower(ChessBoard, Color.White), new ChessPosition('c', 1).ToPosition());
            ChessBoard.PutPiece(new Tower(ChessBoard, Color.White), new ChessPosition('c', 2).ToPosition());
            ChessBoard.PutPiece(new Tower(ChessBoard, Color.White), new ChessPosition('d', 2).ToPosition());
            ChessBoard.PutPiece(new Tower(ChessBoard, Color.White), new ChessPosition('e', 2).ToPosition());
            ChessBoard.PutPiece(new Tower(ChessBoard, Color.White), new ChessPosition('e', 1).ToPosition());
            ChessBoard.PutPiece(new King(ChessBoard, Color.White), new ChessPosition('d', 1).ToPosition());

            // Black's pieces
            ChessBoard.PutPiece(new Tower(ChessBoard, Color.DarkGray), new ChessPosition('c', 8).ToPosition());
            ChessBoard.PutPiece(new Tower(ChessBoard, Color.DarkGray), new ChessPosition('c', 7).ToPosition());
            ChessBoard.PutPiece(new Tower(ChessBoard, Color.DarkGray), new ChessPosition('d', 7).ToPosition());
            ChessBoard.PutPiece(new Tower(ChessBoard, Color.DarkGray), new ChessPosition('e', 7).ToPosition());
            ChessBoard.PutPiece(new Tower(ChessBoard, Color.DarkGray), new ChessPosition('e', 8).ToPosition());
            ChessBoard.PutPiece(new King(ChessBoard, Color.DarkGray), new ChessPosition('d', 8).ToPosition());
        }
    }
}
