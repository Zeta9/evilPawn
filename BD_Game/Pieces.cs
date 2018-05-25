using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonAttributes;

namespace Pieces {

    public class Piece : Common {

        public uint positionX {get; set;}
        public uint positionY {get; set;}
        public string colour {get; set;}

        public List<Position> legalMoves = new List<Position>();
    }

    public class Pawn : Piece{

        //constructor
        public Pawn (string colour, uint xCoord, uint yCoord, ref Piece[][] boardPosition) {

            //set colour
            this.colour = colour;

            //set current position
            this.positionX = xCoord;
            this.positionY = yCoord;
            
        }


        public void CalculateLegalMoves(ref Piece[][] boardPosition) {

            //check left attacking square legal
            if (this.positionX > 0 && boardPosition[this.positionX - 1][this.positionY + 1] != null) {
                //if enemy
                if(!(boardPosition[this.positionX - 1][this.positionY + 1].colour).Equals(this.colour)) {
                    //add to legal moves
                    legalMoves.Add(new Position(this.positionX - 1, this.positionY + 1));
                }
            }
            //check right attaching square
            if (this.positionX < 7 && boardPosition[this.positionX + 1][this.positionY + 1] != null) {
                //if enemy
                if (!(boardPosition[this.positionX + 1][this.positionY + 1].colour).Equals(this.colour)) {
                    //add to legal moves
                    legalMoves.Add(new Position(this.positionX + 1, this.positionY + 1));
                }
            }

            //1 move rule
            if(boardPosition[this.positionX][this.positionY + 1] == null) {
                //add to legal moves
                legalMoves.Add(new Position(this.positionX, this.positionY + 1));

            // 2 move rule
            } else if (this.positionY == 1 && boardPosition[this.positionX][this.positionY + 2] == null) {
                //add to legal moves
                legalMoves.Add(new Position(this.positionX, this.positionY + 2));
            }

            //CALL checkIFPinned function (legalMoves)
        }
    }


    class Knight : Piece {


        //constructor
        public Knight(string colour, uint xCoord, uint yCoord, ref Piece[][] boardPosition) {

            //set colour
            this.colour = colour;

            //set current position
            this.positionX = xCoord;
            this.positionY = yCoord;
        }


        public void CalculateLegalMoves(ref Piece[][] boardPosition) {

            for(int i = -2; i <= 2; i++) {

                int yValue = 0;

                //calculate y value
                if(Math.Abs(i) == 1) {
                    yValue = 2;
                } else {
                    yValue = 1;
                }

                //Calculate top move
                if(this.positionX + i <= 8 && this.positionX + i >= 1 && this.positionY + yValue <= 8 && this.positionY + yValue >= 1 
                    && !(boardPosition[this.positionX + i][this.positionY + yValue].Equals(this.colour))) {

                    
                    //add legal move
                    legalMoves.Add(new Position((uint)(this.positionX + i), (uint)(this.positionY + yValue)));
                }

                //Calculate bottom move
                if (this.positionX + i <= 8 && this.positionX + i >= 1 && this.positionY - yValue <= 8 && this.positionY - yValue >= 1
                    && !(boardPosition[this.positionX + i][this.positionY - yValue].Equals(this.colour))) {

                    //add legal move
                    legalMoves.Add(new Position((uint)(this.positionX + i), (uint)(this.positionY - yValue)));
                }

            }



        }
    }




    class Rook : Piece {
        public int LegalMoves() {


            return 0;
        }
    }
    


    

    class Bishop : Piece {


        public Bishop (string colour, uint xCoord, uint yCoord, ref Piece[][] boardPosition) {
            //set colour
            this.colour = colour;

            //set current position
            this.positionX = xCoord;
            this.positionY = yCoord;

        }

        public void CalculateLegalMoves(ref string[][] BoardPosition) {


            bool P1 = true, P2 = true, P3 = true, P4 = true;
            int i = 1;

            while(P1 == true && P2 == true && P3 == true && P4 == true) {

                //check Left boundary
                if (this.positionX - i < 0) {
                    P1 = false;
                    P3 = false;
                }

                //check Right boundary
                if (this.positionX + i > 7) {
                    P2 = false;
                    P4 = false;
                }
            
                //check Top boundary
                if (this.positionY + i > 7) {
                    P1 = false;
                    P2 = false;
                }

                //check Bottom boundary
                if (this.positionY - i < 0) {
                    P3 = false;
                    P4 = false;
                }

                // check path Top right
                if (BoardPosition[this.positionX + i][this.positionY + i] != null) {
                    //check if enemy ... add to list
                    if (!BoardPosition[this.positionX + i][this.positionY + i].Equals(this.colour)) {
                        //add legal move
                        legalMoves.Add(new Position((uint)(this.positionX + i), (uint)(this.positionY + i)));
                       
                    }
                    
                    //close path
                    P2 = true;
                } else {
                    //add legal move
                    legalMoves.Add(new Position((uint)(this.positionX + i), (uint)(this.positionY + i)));
                }


                // check path Bottom right
                if (BoardPosition[this.positionX + i][this.positionY - i] != null) {
                    //check if enemy ... add to list
                    if (!BoardPosition[this.positionX + i][this.positionY - i].Equals(this.colour)) {
                        //add legal move
                        legalMoves.Add(new Position((uint)(this.positionX + i), (uint)(this.positionY - i)));

                    }

                    //close path
                    P4 = true;

                } else {
                    //add legal move
                    legalMoves.Add(new Position((uint)(this.positionX + i), (uint)(this.positionY - i)));
                }

                // check path Top left
                if (BoardPosition[this.positionX - i][this.positionY + i] != null) {
                    //check if enemy ... add to list
                    if (!BoardPosition[this.positionX - i][this.positionY + i].Equals(this.colour)) {
                        //add legal move
                        legalMoves.Add(new Position((uint)(this.positionX - i), (uint)(this.positionY + i)));

                    }

                    //close path
                    P1 = true;

                } else {
                    //add legal move
                    legalMoves.Add(new Position((uint)(this.positionX - i), (uint)(this.positionY + i)));
                }

                // check path Bottom left
                if (BoardPosition[this.positionX - i][this.positionY - i] != null) {
                    //check if enemy ... add to list
                    if (!BoardPosition[this.positionX - i][this.positionY - i].Equals(this.colour)) {
                        //add legal move
                        legalMoves.Add(new Position((uint)(this.positionX - i), (uint)(this.positionY - i)));

                    }

                    //close path
                    P3 = true;

                } else {
                    //add legal move
                    legalMoves.Add(new Position((uint)(this.positionX - i), (uint)(this.positionY - i)));
                }

                i++; //increment counter
            }
        }
    }



    class King : Piece {
        public int LegalMoves(ref string[][] BoardPosition) {



            return 0;

        }
    }

    class Queen : Piece {

    }

}
