using System;
using BD_Game;
using Pieces;

namespace CommonAttributes {
    public abstract class Common
    {
        public static string piece_with_move_to_string (Piece pc, bool isTaking, string tile_to_move_to)
        {
            string result = "";
            Type type = pc.GetType();
            if (type == typeof(Pawn))
                result = position_to_string(pc.GetPosition()) + ((isTaking) ? "x" : "-") + tile_to_move_to;
            else if (type.Equals(typeof(Rook)))
                result = "R" + position_to_string(pc.GetPosition()) + ((isTaking) ? "x" : "-") + tile_to_move_to;
            else if (type.Equals(typeof(Knight)))
                result = "N" + position_to_string(pc.GetPosition()) + ((isTaking) ? "x" : "-") + tile_to_move_to;
            else if (type.Equals(typeof(Bishop)))
                result = "B" + position_to_string(pc.GetPosition()) + ((isTaking) ? "x" : "-") + tile_to_move_to;
            else if (type.Equals(typeof(King)))
                result = "K" + position_to_string(pc.GetPosition()) + ((isTaking) ? "x" : "-") + tile_to_move_to;
            else if (type.Equals(typeof(Queen)))
                result = "Q" + position_to_string(pc.GetPosition()) + ((isTaking) ? "x" : "-") + tile_to_move_to;
            else
                Console.Error.Write("UNKNOWN PIECE TYPE");
            return result;
        }

        public static Position string_to_position (string two_char_string)
        {
            uint x = (uint)two_char_string[0] - 'A';
            uint y = (uint)two_char_string[1] - '1';
            return new Position(x, y);
        }

        public static string position_to_string (Position position)
        {
            char number = (char) ('1' + position.y);
            char letter = (char) ('A' + position.x);
            return letter.ToString() + number.ToString();
        }

        public struct Position
        {
            public uint x, y;
            public Position(uint p1, uint p2)
            {
                x = p1; y = p2;
            }
        } 
    }
}
