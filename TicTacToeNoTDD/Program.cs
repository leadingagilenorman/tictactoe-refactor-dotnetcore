using System;
namespace TicTacToeNoTDD
{
    /*******************
     * 0 #  1 #2
     * ###############
     * 3 # 4  # 5
     * ##############
     * 6 # 7 # 8
     * 
     * 
     * 
     * 
     * *******************/
    class MainClass
    {
        public static void Main(string[] args)
        {
            var gameboard = new GameBoard();

            Console.WriteLine("Norman's Game of Tic Tac Toe!");
            while (true)
            {
                Console.WriteLine("{0} what is your move?", gameboard.MarkerCurrentTurn.ToString());
                var input = Console.ReadLine();
                int index = int.MinValue;
                try
                {
                    index = Convert.ToInt32(input);
                } catch( FormatException){
                    Console.WriteLine("Stop cheating!!! You lose!");
                    break;
                }

                if(index < 0 || index > 8){
                    Console.WriteLine("Stop cheating!!! You lose!");
                    break;
                }
              
                try{
                    
                    gameboard.Move(index);

                }catch(GameBoard.CheatingException ex){
                    Console.WriteLine(ex.Message);
                    break;
                }

                if(gameboard.IsGameOver()){
                    //figure out who won!

                    Console.WriteLine("{0} is winner", gameboard.GetWinner());
                    break;

                }

            }



        }
    }
    public enum Marker {
        X = 0,
        O = 1

    }
}
