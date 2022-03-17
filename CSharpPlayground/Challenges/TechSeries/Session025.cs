using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session25
{
    public class Session25
    {
        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {
            var grid = new Grid();
            grid.Matrix = new List<List<int>> { 
                new List<int>() { 1,  2,  3,  4,  5 },
                new List<int>() { 6,  7,  8,  9,  10 },
                new List<int>() { 11, 12, 13, 14, 15 },
                new List<int>() { 16, 17, 18, 19, 20 },
            };
            grid.SpiralPrint();
        }
    }

    public class Grid
    {
        public List<List<int>> Matrix;

        public enum Direction
        {
            Right, Left, Up, Down,
        }

        public Grid()
        {
            Matrix = new List<List<int>>();
        }       

        public void SpiralPrint()
        {
            var result = new StringBuilder();

            var remaining = Matrix.Count * Matrix[0].Count;
            var currentDirection = Direction.Right;
            var currentPosition = (row: 0, col: 0);

            while (remaining > 0)
            {
                result.Append($"{Matrix[currentPosition.row][currentPosition.col]} ");
                Matrix[currentPosition.row][currentPosition.col] = 0;
                var nextPosition = GetNextPosition(currentPosition, currentDirection);

                if (!IsValidPosition(nextPosition))
                {
                    currentDirection = GetNextDirection(currentDirection);
                    currentPosition = GetNextPosition(currentPosition, currentDirection);
                }
                else
                {
                    currentPosition = GetNextPosition(currentPosition, currentDirection);
                }

                remaining--;
            }
            WriteLine(result.ToString());
        }

        private (int row, int col) GetNextPosition((int row, int col) position, Direction direction)
        {
            if (direction == Direction.Right)
            {
                return (position.row, position.col + 1);
            }
            else if (direction == Direction.Down)
            {
                return (position.row + 1, position.col);
            }
            else if (direction == Direction.Up)
            {
                return (position.row -1, position.col);
            }
            else
            {
                return (position.row, position.col - 1);
            }
        }

        private Direction GetNextDirection(Direction direction)
        {
            if (direction == Direction.Right)
            {
                direction = Direction.Down;
            }
            else if (direction == Direction.Left)
            {
                direction = Direction.Up;
            }
            else if (direction == Direction.Up)
            {
                direction = Direction.Right;
            }
            else if (direction == Direction.Down)
            {
                direction = Direction.Left;
            }
            return direction;
        }

        private bool IsValidPosition((int row, int col) position)
        {
            if (position.row >= 0 && position.row <= Matrix.Count - 1
                && position.col >= 0 && position.col <= Matrix[0].Count - 1
                && Matrix[position.row][position.col] != 0)
            {
                return true;
            }
            return false;
        }
    }
}
