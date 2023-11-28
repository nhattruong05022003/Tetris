using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class OBlock : Block
    {
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] { new Position(0, 0),new Position(0, 1),new Position(1, 0),new Position(1, 1) }
        };

        public override int Id => 4; // set id = 1
        protected override Position StartOffset => new Position(0, 3); // vị trí spam (ở giữa của hàng đầu tiên)
        protected override Position[][] Tiles => tiles;
    }
}
