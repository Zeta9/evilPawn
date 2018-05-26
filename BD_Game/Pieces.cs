using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonAttributes;

namespace Pieces {

    public abstract class Piece : Common {

        public uint positionX {get; set;}
        public uint positionY {get; set;}
        public string colour {get; set;}

        public List<Position> legalMoves = new List<Position>();

        public abstract void CalculateLegalMoves(ref Piece[][] boardPosition);
    }

    public class Pawn : Piece{

        //constructor
        public Pawn (string colour, uint xCoord, uint yCoord) {

            //set colour
            this.colour = colour;

            //set current position
            this.positionX = xCoord;
            this.positionY = yCoord;
            
        }


        public override void CalculateLegalMoves(ref Piece[][] boardPosition) {

            //check left attacking square legal
            if (this.positionX - 1 >= 0 && this.positionY + 1 <= 7){
                if(boardPosition[this.positionX - 1][this.positionY + 1] != null) {
                    //if enemy
                    if(!(boardPosition[this.positionX - 1][this.positionY + 1].colour).Equals(this.colour)) {
                        //add to legal moves
                        legalMoves.Add(new Position(this.positionX - 1, this.positionY + 1));
                    }
                }
            }
            //check right attaching square
            if (this.positionX + 1 <= 7 && this.positionY + 1 <= 7){
                if(boardPosition[this.positionX + 1][this.positionY + 1] != null) {
                    //if enemy
                    if (!(boardPosition[this.positionX + 1][this.positionY + 1].colour).Equals(this.colour)) {
                        //add to legal moves
                        legalMoves.Add(new Position(this.positionX + 1, this.positionY + 1));
                    }
                }
            }

            if(this.positionY + 1 <= 7){
                //1 move rule
                if(boardPosition[this.positionX][this.positionY + 1] == null) {
                    //add to legal moves
                    legalMoves.Add(new Position(this.positionX, this.positionY + 1));
                } 
             } else if(this.positionY + 2 <= 7){ 
                if (this.positionY == 1 && boardPosition[this.positionX][this.positionY + 2] == null) {// 2 move rule
                    //add to legal moves
                    legalMoves.Add(new Position(this.positionX, this.positionY + 2));
                }
            }

            //CALL checkIFPinned function (legalMoves)
        }
    }


    class Knight : Piece {


        //constructor
        public Knight(string colour, uint xCoord, uint yCoord) {

            //set colour
            this.colour = colour;

            //set current position
            this.positionX = xCoord;
            this.positionY = yCoord;
        }


        public override void CalculateLegalMoves(ref Piece[][] boardPosition) {

            for(int i = -2; i <= 2; i++) {

                int yValue = 0;

                //calculate y value
                if(Math.Abs(i) == 1) {
                    yValue = 2;
                } else {
                    yValue = 1;
                }

                //Calculate top move
                if(this.positionX + i <= 7 && this.positionX + i >= 0 && this.positionY + yValue <= 7 && this.positionY + yValue >= 0){
                    if(!(boardPosition[this.positionX + i][this.positionY + yValue].Equals(this.colour))) {
                        //add legal move
                        legalMoves.Add(new Position((uint)(this.positionX + i), (uint)(this.positionY + yValue)));
                    }
                }

                //Calculate bottom move
                if (this.positionX + i <= 7 && this.positionX + i >= 0 && this.positionY - yValue <= 7 && this.positionY - yValue >= 0){
                   if(!(boardPosition[this.positionX + i][this.positionY - yValue].Equals(this.colour))) {
                        //add legal move
                        legalMoves.Add(new Position((uint)(this.positionX + i), (uint)(this.positionY - yValue)));
                    }
                }

            }



        }
    }




    class Rook : Piece {




        public Rook(string colour, uint xCoord, uint yCoord) {
            //set colour
            this.colour = colour;

            //set current position
            this.positionX = xCoord;
            this.positionY = yCoord;

        }

        public override void CalculateLegalMoves(ref Piece[][] BoardPosition) {
            /*      P2
             *      +
             * P1 + + + P3
             *      +
             *      P4
             */


            bool P1 = true, P2 = true, P3 = true, P4 = true;
            int i = 1;

            //while any path clear
            while (P1 == true || P2 == true || P3 == true || P4 == true) {

                //check Left boundary
                if (this.positionX - i < 0) {
                    P1 = false;
                    P2 = false;
                    P4 = false;
                }
                
                //check Right boundary
                if (this.positionX + i > 7) {
                    P2 = false;
                    P3 = false;
                    P4 = false;
                }

                //check Top boundary
                if (this.positionY + i > 7) {
                    P1 = false;
                    P2 = false;
                    P3 = false;
                }

                //check Bottom boundary
                if (this.positionY - i < 0) {
                    P1 = false;
                    P3 = false;
                    P4 = false;
                }

                //boundary check Left
                if (this.positionX - i >= 0) {
                    // check path Left
                    if (BoardPosition[this.positionX - i][this.positionY] != null) {
                        //check if enemy ... add to list
                        if (!BoardPosition[this.positionX - i][this.positionY].Equals(this.colour)) {
                            //add legal move
                            legalMoves.Add(new Position((uint)(this.positionX - i), (uint)(this.positionY)));
                        }

                        //close path - one piece taken at a time
                        P2 = false;
                    } else {
                        //add empty square to legal moves
                        legalMoves.Add(new Position((uint)(this.positionX - i), (uint)(this.positionY)));
                    }

                }

                //boundary check Top
                if (this.positionY + i >= 0) {
                    // check path Top
                    if (BoardPosition[this.positionX][this.positionY + i] != null) {
                        //check if enemy ... add to list
                        if (!BoardPosition[this.positionX][this.positionY + i].Equals(this.colour)) {
                            //add legal move
                            legalMoves.Add(new Position((uint)(this.positionX), (uint)(this.positionY + i)));
                         }

                        //close path - one piece taken at a time
                        P4 = false;

                    } else {
                        //add empty square to legal moves
                        legalMoves.Add(new Position((uint)(this.positionX), (uint)(this.positionY + i)));
                    }
                }

                //boundary check Right
                if (this.positionX + i <= 7) {
                    // check path Right
                    if (BoardPosition[this.positionX + i][this.positionY] != null) {
                        //check if enemy ... add to list
                        if (!BoardPosition[this.positionX + i][this.positionY].Equals(this.colour)) {
                            //add legal move
                            legalMoves.Add(new Position((uint)(this.positionX + i), (uint)(this.positionY)));

                        }

                        //close path - one piece taken at a time
                        P1 = false;

                    } else {
                        //add empty square to legal moves
                        legalMoves.Add(new Position((uint)(this.positionX + i), (uint)(this.positionY)));
                    }
                }


                //boundary check Bottom
                if (this.positionY - i >= 0) {
                    // check path Bottom left
                    if (BoardPosition[this.positionX][this.positionY - i] != null) {
                        //check if enemy ... add to list
                        if (!BoardPosition[this.positionX][this.positionY - i].Equals(this.colour)) {
                            //add legal move
                            legalMoves.Add(new Position((uint)(this.positionX), (uint)(this.positionY - i)));

                        }

                        //close path - one piece taken at a time
                        P3 = false;

                    } else {
                        //add empty square to legal moves
                        legalMoves.Add(new Position((uint)(this.positionX), (uint)(this.positionY - i)));
                    }
                }

                i++; //increment counter
            }
        }

    }
    
    


    

    class Bishop : Piece {


        public Bishop (string colour, uint xCoord, uint yCoord) {
            //set colour
            this.colour = colour;

            //set current position
            this.positionX = xCoord;
            this.positionY = yCoord;

        }

        public override void CalculateLegalMoves(ref Piece[][] BoardPosition) {

            /*  P1    P2
            *     \ /
            *      + 
            *     / \
            *  P3     P4
            */


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

                //boundary check
                if(this.positionX + i <= 7 && this.positionY + i <= 7){
                    // check path Top right
                    if (BoardPosition[this.positionX + i][this.positionY + i] != null) {
                        //check if enemy ... add to list
                        if (!BoardPosition[this.positionX + i][this.positionY + i].Equals(this.colour)) {
                            //add legal move
                            legalMoves.Add(new Position((uint)(this.positionX + i), (uint)(this.positionY + i)));
                       
                        }

                        //close path - one piece taken at a time
                        P2 = false;
                    } else {
                        //add empty square to legal moves
                        legalMoves.Add(new Position((uint)(this.positionX + i), (uint)(this.positionY + i)));
                    }

                }

                //boundary check
                if (this.positionX + i <= 7 && this.positionY - i >= 0) {
                    // check path Bottom right
                    if (BoardPosition[this.positionX + i][this.positionY - i] != null) {
                        //check if enemy ... add to list
                        if (!BoardPosition[this.positionX + i][this.positionY - i].Equals(this.colour)) {
                            //add legal move
                            legalMoves.Add(new Position((uint)(this.positionX + i), (uint)(this.positionY - i)));

                        }

                        //close path - one piece taken at a time
                        P4 = false;

                    } else {
                        //add empty square to legal moves
                        legalMoves.Add(new Position((uint)(this.positionX + i), (uint)(this.positionY - i)));
                    }
                }

                //boundary check
                if (this.positionX - i >= 0 && this.positionY + i <= 7) {
                    // check path Top left
                    if (BoardPosition[this.positionX - i][this.positionY + i] != null) {
                        //check if enemy ... add to list
                        if (!BoardPosition[this.positionX - i][this.positionY + i].Equals(this.colour)) {
                            //add legal move
                            legalMoves.Add(new Position((uint)(this.positionX - i), (uint)(this.positionY + i)));

                        }

                        //close path - one piece taken at a time
                        P1 = false;

                    } else {
                        //add empty square to legal moves
                        legalMoves.Add(new Position((uint)(this.positionX - i), (uint)(this.positionY + i)));
                    }
                }


                //boundary check
                if (this.positionX - i >= 0 && this.positionY - i >= 0) {
                    // check path Bottom left
                    if (BoardPosition[this.positionX - i][this.positionY - i] != null) {
                        //check if enemy ... add to list
                        if (!BoardPosition[this.positionX - i][this.positionY - i].Equals(this.colour)) {
                            //add legal move
                            legalMoves.Add(new Position((uint)(this.positionX - i), (uint)(this.positionY - i)));

                        }

                        //close path - one piece taken at a time
                        P3 = false;

                    } else {
                        //add empty square to legal moves
                        legalMoves.Add(new Position((uint)(this.positionX - i), (uint)(this.positionY - i)));
                    }
                }

                    i++; //increment counter
            }
        }
    }



    class King : Piece {


        public King(string colour, uint xCoord, uint yCoord) {
            //set colour
            this.colour = colour;

            //set current position
            this.positionX = xCoord;
            this.positionY = yCoord;

        }
        public override void CalculateLegalMoves(ref Piece[][] BoardPosition) {



        }
    }

    class Queen : Piece {
        public Queen(string colour, uint xCoord, uint yCoord) {
            //set colour
            this.colour = colour;

            //set current position
            this.positionX = xCoord;
            this.positionY = yCoord;

        }

        public override void CalculateLegalMoves(ref Piece[][] BoardPosition) {



        }
    }

}
