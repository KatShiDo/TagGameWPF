using System;

namespace TagGameLib
{
    public enum MoveDirection
    {
        Up,
        Down,
        Left,
        Right,
        None
    }
    
    public class ModelGame
    {
        private readonly Random _rnd = new Random();
        private readonly int[,] _map = new int[4, 4];

        public event EventHandler<int[,]> RePaint;

        public int Step { get; private set; }
        
        public int this[int row, int col] => _map[row, col];

        public void Init()
        {
            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    _map[i, j] = (i * 4 + j + 1) % 16;
                }
            }

            Mix();
            Step = 0;
            RePaint?.Invoke(this, _map);
        }

        private void Mix()
        {
            for (var i = 0; i < 100; i++)
            {
                switch (_rnd.Next(2) + i % 2 * 2)
                {
                    case 0: ToLeft();
                        break;
                    case 1: ToRight();
                        break;
                    case 2: ToUp();
                        break;
                    case 3: ToDown();
                        break;
                }
            }
        }

        public bool Win()
        {
            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    if (_map[i, j] != (i * 4 + j + 1) % 16)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private (int, int) FindSpace()
        {
            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    if (_map[i, j] == 0)
                    {
                        return (i, j);
                    }
                }
            }

            throw new ArgumentException("Something wrong!!!");
        }

        static void Swap(ref int a, ref int b) => (a, b) = (b, a);
        
        private void ToDown()
        {
            var (r, c) = FindSpace();
            if (r > 0)
            {
                Swap(ref _map[r - 1, c], ref _map[r, c]);
                Step++;
            }
        }

        private void ToUp()
        {
            var (r, c) = FindSpace();
            if (r < 3)
            {
                Swap(ref _map[r, c], ref _map[r + 1, c]);
                Step++;
            }
        }

        private void ToRight()
        {
            var (r, c) = FindSpace();
            if (c > 0)
            {
                Swap(ref _map[r, c], ref _map[r, c - 1]);
                Step++;
            }
        }

        private void ToLeft()
        {
            var (r, c) = FindSpace();
            if (c < 3)
            {
                Swap(ref _map[r, c], ref _map[r, c + 1]);
                Step++;
            }
        }

        public void KeyDown(MoveDirection key)
        {
            switch (key)
            {
                case MoveDirection.Left: ToLeft();
                    break;
                case MoveDirection.Right: ToRight();
                    break;
                case MoveDirection.Up: ToUp();
                    break;
                case MoveDirection.Down: ToDown();
                    break;
            }

            RePaint?.Invoke(this, _map);
        }
    }
}