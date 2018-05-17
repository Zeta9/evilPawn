using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD_Game{
    class Game {

        public uint timeInterval;
        public uint timePadding;

        //default constructor
        Game(uint timeInterval, uint timePadding){
            //create all peices
            this.timeInterval = timeInterval;
            this.timePadding = timePadding;

            for (int i = 0; i < 7; i++){
                Pawn B_pawn = new Pawn();
            }
        }


    }

    






















}
