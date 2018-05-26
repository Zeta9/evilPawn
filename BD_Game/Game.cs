using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonAttributes;
using Pieces;


namespace BD_Game{
    class Game {

        public uint timeInterval;
        public uint timePadding;
        public Piece[][] boardPosition = new Piece[8][8];

        //default constructor
        Game(uint timeInterval, uint timePadding){
            //create all peices
            this.timeInterval = timeInterval;
            this.timePadding = timePadding;

            // setting board
            setBoard();

            
            
        }


        public void setBoard() {

            //load in pawns
            for(uint i = 0; i <= 7; i++) {
                this.boardPosition[i][1] = new Pawn("white", i, 1);
                this.boardPosition[i][6] = new Pawn("black", i, 7);
            }

            
            //load in Rooks
            this.boardPosition[0][0] = new Rook("white", 0, 0);
            this.boardPosition[7][0] = new Rook("black", 7, 0);
            this.boardPosition[0][7] = new Rook("white", 0, 7);
            this.boardPosition[7][7] = new Rook("black", 7, 7);

            //load in Knights
            this.boardPosition[1][0] = new Knight("white", 1, 0);
            this.boardPosition[6][0] = new Knight("black", 6, 0);
            this.boardPosition[1][7] = new Knight("white", 1, 7);
            this.boardPosition[6][7] = new Knight("black", 6, 7);

            //load in Bishops
            this.boardPosition[2][0] = new Bishop("white", 2, 0);
            this.boardPosition[5][0] = new Bishop("black", 5, 0);
            this.boardPosition[2][7] = new Bishop("white", 2, 7);
            this.boardPosition[5][7] = new Bishop("black", 5, 7);

            //load in Queens
            this.boardPosition[3][0] = new Queen("white", 3, 0);
            this.boardPosition[4][7] = new Queen("black", 4, 7);

            //load in Kings
            this.boardPosition[4][0] = new King("white", 4, 0);
            this.boardPosition[3][7] = new King("black", 3, 7);

        }

        public void printLegalMoves() {

            this.boardPosition[0][0].CalculateLegalMoves(ref this.boardPosition);

            foreach (Position i in this.boardPosition[0][0].legalMoves) {
                Console.WriteLine(i.x);
                Console.WriteLine(i.y);
            }
            this.boardPosition[0][0].legalMoves.ForEach(Console.WriteLine);




        }


    }

    






















}
