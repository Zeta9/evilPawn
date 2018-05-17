using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD_Game {

    public class Piece {

        public uint positionX;
        public uint positionY;
        public string colour;

    }

    public class Pawn : Piece{

        //default constructor
        public Pawn (uint xCoord, uint yCoord, ref Piece[][] boardPosition) {

            //set current position
            this.positionX = xCoord;
            this.positionY = yCoord;
        }


        public int LegalMoves() {

            //check left attacking square
            if (positionX > 0) {
                //if enemy
                if(boardPosition[positionX-1][positionY+1] != null && !(getColour().Equals(this.colour))) {
                    //add to legal moves
                    
                }
            }
            //check right attaching square
            if (positionX < 7){
                //if enemy
                if (boardPosition[positionX + 1][positionY + 1] != null && !(getColour().Equals(this.colour))) {
                    //add to legal moves
                }
            }

            //2 move rule
            if (positionY == 1) {
                //add to legal moves
                
            }

            //1 move rule
            if(boardPosition[positionX][positionY + 1] != null) {
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
