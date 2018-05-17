using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD_Game {

    public class Piece {

        public uint positionX;
        public uint positionY;
        private string colour;

        //Accessors
     
        public string getColour() {
            return this.colour;
        }

        public void setColour(string col) {
            this.colour = col;
        }

    }

    public class Pawn : Piece{

        //default constructor
        public Pawn (string colour, uint xCoord, uint yCoord, ref Piece[][] boardPosition) {

            //set colour
            this.setColour(colour);

            //set current position
            this.positionX = xCoord;
            this.positionY = yCoord;
            
        }


        public int LegalMoves(ref Piece[][] boardPosition) {

            //check left attacking square
            if (positionX > 0 && boardPosition[positionX - 1][positionY + 1] != null) {
                //if enemy
                if(!(boardPosition[positionX - 1][positionY + 1].getColour().Equals(this.getColour()))) { // had at just colour
                    //add to legal moves
                    
                }
            }
            //check right attaching square
            if (positionX < 7 && boardPosition[positionX + 1][positionY + 1] != null) {
                //if enemy
                if (!(boardPosition[positionX + 1][positionY + 1].getColour().Equals(this.getColour()))) {
                    //add to legal moves
                }
            }

            //1 move rule
            if(boardPosition[positionX][positionY + 1] == null) {
                //add to legal moves

            } else if (positionY == 1 && boardPosition[positionX][positionY + 2] == null) { // 2 move rull
                //add to legal moves

            }
        }
    }

    class Rook : Piece {
        public int LegalMoves() {


            return 0;
        }
    }
    


    class Knight : Piece {

    }

    class Bishop : Piece {

    }



    class King : Piece {
        public int LegalMoves(ref string[][] BoardPosition) {



            return 0;

        }
    }

    class Queen : Piece {

    }

}
