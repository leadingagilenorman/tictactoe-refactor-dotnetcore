using System;
using System.Linq;
namespace TicTacToeNoTDD
{
    public class GameBoard
    {

        public GameBoard()
        {
            this.Spaces = new Marker?[9];
            this.MarkerCurrentTurn = Marker.X;
        }

        public Marker MarkerCurrentTurn { get; private set; }
        public Marker?[] Spaces { get; private set; }



        public void Move(int index)
        {

            if (this.Spaces[index].HasValue)
            {
                throw new CheatingException();
            }
            else
            {

                //set the turn
                this.Spaces[index] = this.MarkerCurrentTurn;

                //swap the turn
                this.MarkerCurrentTurn = this.MarkerCurrentTurn == Marker.X ?
                    Marker.O : Marker.X;
            }
        }

        public bool HasWinner()
        {

            var row1 = this.Spaces.Skip(0).Take(3).ToArray();
            var row2 = this.Spaces.Skip(3).Take(3).ToArray();
            var row3 = this.Spaces.Skip(6).Take(3).ToArray();

            var col1 = new Marker?[] { this.Spaces[0], this.Spaces[3], this.Spaces[6] };
            var col2 = new Marker?[] { this.Spaces[1], this.Spaces[4], this.Spaces[7] };
            var col3 = new Marker?[] { this.Spaces[2], this.Spaces[5], this.Spaces[8] };

            var diag1 = new Marker?[] { this.Spaces[0], this.Spaces[4], this.Spaces[8] };
            var diag2 = new Marker?[] { this.Spaces[6], this.Spaces[4], this.Spaces[2] };

            if (this.isWinner(row1))
            {
                return true;
            }

            if (this.isWinner(row2))
            {
                return true;
            }

            if (this.isWinner(row3))
            {
                return true;
            }

            if (this.isWinner(col1))
            {
                return true;
            }

            if (this.isWinner(col2))
            {
                return true;
            }

            if (this.isWinner(col3))
            {
                return true;
            }

            if (this.isWinner(diag1))
            {
                return true;
            }

            if (this.isWinner(diag2))
            {
                return true;
            }

            return false;




        }

        private bool isWinner(Marker?[] markers)
        {
            if (markers.Count(x => x.HasValue) == 3)
            {
                return markers.Distinct().Count() == 1;
            }
            return false;// no winner here.

        }

        public Marker? GetWinner()
        {
            if (this.HasWinner())
            {
                return this.MarkerCurrentTurn == Marker.X ?
                           Marker.O : Marker.X;


            }

            return null;
        }
        public bool IsGameOver()
        {
            if (HasWinner())
            {
                return true;
            }
            return this.Spaces.Count(x => x.HasValue) == this.Spaces.Length;
        }

        public class CheatingException : Exception
        {
            public CheatingException() : base("This space is occupied, cheater!") { }
        }

    }
}
