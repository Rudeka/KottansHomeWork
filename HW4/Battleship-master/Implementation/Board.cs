//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Implementation
//{
//    public class Board
//    {
//        private List<Board> boards;
//        public int CoorX { get; }
//        public int CoorY { get; }

//        public Board(int xCoor, int yCoor)
//        {
//            CoorX = xCoor;
//            CoorY = yCoor;
//        }

//        public void Add(Board boardType)
//        {
//            try
//            {
//                for (int i = 0; i < boards.Count; i++)
//                {
//                    if (boardType.CoorX == boards[i].CoorX)
//                    {
//                        throw
//                    }
//                }
//            }
//            boards = new List<Board>() { boardType };
//        }

//        public List<Board> GetAll()
//        {
//            return boards;
//        }
//    }
//}
