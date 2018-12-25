using System;
using System.Collections.Generic;

using ChessGame.Board;
using ChessGame.Board.Exceptions;
using ChessGame.Chess.Exceptions;

namespace ChessGame.Chess
{
    class ChessMatch
    {
        public ChessBoard ChessBoard { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }
        public List<Piece> InGamePieces { get; private set; }
        public List<Piece> OutOfGamePieces { get; private set; }
        public DateTime StartedAt { get; private set; }
        public DateTime FinishedAt { get; private set; }

        public ChessMatch ()
        {
            ChessBoard = new ChessBoard();
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            StartedAt = DateTime.Now;
            InGamePieces = new List<Piece>();
            OutOfGamePieces = new List<Piece>();

            PlacePieces();
        }

        public void ExecuteMovement (ChessPosition origin, ChessPosition target)
        {
            var originPiece = ChessBoard.GetPiece(origin.ToPosition());

            if(originPiece.IsPossibleMovement(target.ToPosition()))
            {
                RemovePiece(origin);
                var currentTargetPiece = ChessBoard.GetPiece(target.ToPosition());
                
                if (currentTargetPiece != null)
                    RemovePiece(target, currentTargetPiece);

                InsertPiece(originPiece, target);

                // Verify if the player CHECKED himself
                if (IsInCheck(GetKing(CurrentPlayer)))
                {
                    UndoMovement(origin, target, currentTargetPiece);
                    throw new ChessMatchException("You can't CHECK yourself");
                }

                NextTurn(originPiece);
            }
            else
            {
                throw new ChessMatchException("This piece can't make this movement");
            }
        }

        private void UndoMovement (ChessPosition origin, ChessPosition target, Piece removedPiece)
        {
            var oldOriginPiece = ChessBoard.GetPiece(target.ToPosition());

            RemovePiece(target);
            InsertPiece(oldOriginPiece, origin);
            oldOriginPiece.DecrementMovement();

            if (removedPiece != null)
                InsertNewPiece(removedPiece, target);
        }

        public void CheckOriginPosition (ChessPosition origin)
        {
            if (ChessBoard.PieceExists(origin.ToPosition()))
            {
                if (!ChessBoard.GetPiece(origin.ToPosition()).Color.Equals(CurrentPlayer))
                    throw new ChessMatchException("You can only movement your pieces");
            }
            else
            {
                throw new ChessBoardException("Not exist a piece in this position");
            }
        }

        public void CheckTargetPosition (ChessPosition target)
        {
            ChessBoard.ValidPosition(target.ToPosition());
        }

        public List<Piece> GetInGamePieces (Color color)
        {
            return InGamePieces.FindAll(p => p.Color.Equals(color));
        }

        public List<Piece> GetOutOfGamePieces (Color color)
        {
            return OutOfGamePieces.FindAll(p => p.Color.Equals(color));
        }

        private void PlacePieces ()
        {
            //// White's pieces
            //InsertNewPiece(new Tower(ChessBoard, Color.White), new ChessPosition('a', 1));
            //InsertNewPiece(new Tower(ChessBoard, Color.White), new ChessPosition('h', 1));
            //InsertNewPiece(new King(ChessBoard, Color.White), new ChessPosition('d', 1));
            //InsertNewPiece(new Bishop(ChessBoard, Color.White), new ChessPosition('e', 1));
            //InsertNewPiece(new Bishop(ChessBoard, Color.White), new ChessPosition('c', 1));

            //// White pawns
            //for (var c = 0; c < ChessBoard.Columns; c++)
            //{
            //    char currentColumn = (char)('a' + c);
            //    InsertNewPiece(new Pawn(ChessBoard, Color.White), new ChessPosition(currentColumn, 2));
            //}

            //// Black's pieces
            //InsertNewPiece(new Tower(ChessBoard, Color.DarkGray), new ChessPosition('a', 8));
            //InsertNewPiece(new Tower(ChessBoard, Color.DarkGray), new ChessPosition('h', 8));
            //InsertNewPiece(new King(ChessBoard, Color.DarkGray), new ChessPosition('d', 8));
            //InsertNewPiece(new Bishop(ChessBoard, Color.DarkGray), new ChessPosition('c', 8));
            //InsertNewPiece(new Bishop(ChessBoard, Color.DarkGray), new ChessPosition('e', 8));

            //// Black pawns
            //for (var c = 0; c < ChessBoard.Columns; c++)
            //{
            //    char currentColumn = (char)('a' + c);
            //    InsertNewPiece(new Pawn(ChessBoard, Color.DarkGray), new ChessPosition(currentColumn, 7));
            //}

            InsertNewPiece(new King(ChessBoard, Color.DarkGray), new ChessPosition('e', 8));
            InsertNewPiece(new Tower(ChessBoard, Color.DarkGray), new ChessPosition('e', 7));

            InsertNewPiece(new Tower(ChessBoard, Color.White), new ChessPosition('e', 3));
            InsertNewPiece(new King(ChessBoard, Color.White), new ChessPosition('e', 1));
        }

        private void InsertPiece (Piece piece, ChessPosition chessPosition)
        {
            ChessBoard.PutPiece(piece, chessPosition.ToPosition());
        }

        private void InsertNewPiece (Piece piece, ChessPosition chessPosition)
        {
            ChessBoard.PutPiece(piece, chessPosition.ToPosition());
            
            OutOfGamePieces.Remove(piece);
            InGamePieces.Add(piece);
        }

        private void RemovePiece (ChessPosition chessPosition)
        {
            ChessBoard.RemovePiece(chessPosition.ToPosition());
        }

        private void RemovePiece (ChessPosition chessPosition, Piece piece)
        {
            RemovePiece(chessPosition);

            InGamePieces.Remove(piece);
            OutOfGamePieces.Add(piece);
        }
    
        private void NextTurn (Piece originPiece)
        {
            Turn++;
            originPiece.IncrementMovement();
            CurrentPlayer = (CurrentPlayer.Equals(Color.White)) ? Color.DarkGray : Color.White;
        }
    
        private bool IsInCheck(King king)
        {
            var adversaryPieces = GetInGamePieces(Adversary(king.Color));

            foreach(var currentPiece in adversaryPieces)
                if (currentPiece.IsPossibleMovement(king.Position))
                    return true;

            return false;
        }

        private King GetKing (Color color)
        {
            return (King) GetInGamePieces(color).Find(p => p is King);
        }

        private Color Adversary (Color color)
        {
            return (color.Equals(Color.White)) ? Color.DarkGray : Color.White;
        }
    }
}
