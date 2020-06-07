using System;
using System.Collections.Generic;
using System.Text;

namespace TextGameFramework
{
    public class Transform
    {
        private int _x;
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }


        private int _y;
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }


        public Transform()
        {
            Reset();
        }


        public void Reset()
        {
            X = 1;
            Y = 1;
        }

        public void SetPosition(int x, int y)
        {
            X = x;
            Y = y;
        }

    }
}
