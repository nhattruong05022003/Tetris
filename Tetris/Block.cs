using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    

namespace Tetris
{
    public abstract class  Block
    {
        protected abstract Position[][] Tiles { get; } // các dạng của block
        protected abstract Position StartOffset { get; } // vị trí spam block
        public abstract int Id { get; } // dùng để phân biệt các block

        private int rotationState; // vị trí xoay hiện tại
        private Position offset; // vị trí hiện tại

        public Block()
        {
            offset = new Position(StartOffset.Row, StartOffset.Column); // khởi tạo 1 block tại vị trí spam
        }

        public IEnumerable<Position> TilePosition() // trả về vị trí mà block chiếm chỗ
        {
            foreach (Position p in Tiles[rotationState]) 
            {
                yield return new Position(p.Row + offset.Row, p.Column + offset.Column);
            }
        }

        public void RotateCW() // xoay chiều kim đồng hồ
        {
            rotationState = (rotationState + 1) % Tiles.Length;
        }

        public void RotateCCW() // xoay ngược chiều kim đồng hồ
        {
            if(rotationState == 0)
            {
                rotationState = Tiles.Length - 1;
            }
            else
            {
                rotationState--;
            }
        }

        public void Move(int rows, int columns)
        {
            offset.Row += rows;
            offset.Column += columns;
        }

        public void Reset()
        {
            rotationState = 0;
            offset.Row = StartOffset.Row; 
            offset.Column = StartOffset.Column;
        }
    }
}
