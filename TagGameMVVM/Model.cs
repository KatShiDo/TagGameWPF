using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;

namespace TagGameMVVM
{
    public enum MoveDirection
    {
        Up,
        Down,
        Left,
        Right,
        None
    }

    public class Model : ViewModel
    {
        private int step;
        private string timer;

        private (int r, int c) space;

        private Piece[] _pieces;
        //private ObservableCollection<Piece> _pieces = new ObservableCollection<Piece>();

        private readonly Random _rnd = new Random();

        public Piece[] pieces => _pieces;
        //public ObservableCollection<Piece> pieces => _pieces;

        public int Step => step;

        public event EventHandler WinComplete;

        public Model()
        {
            Init();
        }

        public void Init()
        {
            _pieces = new Piece[15];
            for (var k = 0; k < 15; k++)
            {
                var i = k / 4;
                var j = k % 4;
                _pieces[k] = new Piece(i, j, k + 1);
                //_pieces.Add(new Piece(i, j, k + 1));
            }

            space = (3, 3);
            Mix();
            step = 0;
        }

        private void Mix()
        {
            for (var i = 0; i < 5 /*100*/; i++)
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
            var map = new int[4, 4];
            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    if (map[i, j] != (i * 4 + j + 1) % 16)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        Piece FindPiece(int r, int c) => pieces.Where(f => f.IsHere(r, c)).FirstOrDefault();

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
        }

        Piece MoveFrom(int r, int c)
        {
            var p = FindPiece(r, c);
            if (p != null)
            {
                space = (r, c);
            }

            return p;
        }

        public void ToLeft()
        { 
            MoveFrom(space.r, space.c + 1)?.ToLeft(ref step);
            Fire(nameof(Step));
        }

        public void ToRight()
        {
            MoveFrom(space.r, space.c - 1)?.ToRight(ref step);
            Fire(nameof(Step));
        }

        public void ToUp()
        {
            MoveFrom(space.r + 1, space.c)?.ToUp(ref step);
            Fire(nameof(Step));
        }

        public void ToDown()
        {
            MoveFrom(space.r - 1, space.c)?.ToDown(ref step);
            Fire(nameof(Step));
        }

        public void PressBy(Piece piece)
        {
            if (piece.IsHere(space.r + 1, space.c)) ToUp();
            else if (piece.IsHere(space.r - 1, space.c)) ToDown();
            else if (piece.IsHere(space.r, space.c + 1)) ToLeft();
            else if (piece.IsHere(space.r, space.c - 1)) ToRight();
        }
    }

    public class Piece : ViewModel
    {
        private int r, c;

        public int X => c * 110;
        public int Y => r * 110;

        public void ToDown(ref int step)
        {
            if (r < 3)
            {
                r++;
                Fire(nameof(Y));
                step++;
            }
        }

        public void ToUp(ref int step)
        {
            if (r > 0)
            {
                r--;
                Fire(nameof(Y));
                step++;
            }
        }

        public void ToRight(ref int step)
        {
            if (c < 3)
            {
                c++;
                Fire(nameof(X));
                step++;
            }
        }

        public void ToLeft(ref int step)
        {
            if (c > 0)
            {
                c--;
                Fire(nameof(X));
                step++;
            }
        }
        
        public int Num { get; private set; }

        public Piece(int r, int c, int num)
        {
            Num = num;
            this.r = r;
            this.c = c;
        }

        public bool IsHere(int r, int c) => r == this.r && c == this.c;
    }
}