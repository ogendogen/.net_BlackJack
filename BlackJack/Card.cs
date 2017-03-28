using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Card
    {
        public enum Colours { Heart, Diamond, Club, Spade}
        private Bitmap image;
        private string name;
        private char figure;
        private int points;
        private Colours colour;
        private bool is_ace;
        private bool is_used;

        public Bitmap Image
        {
            get
            {
                return image;
            }
            set
            {
                if (value != null) image = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public char Figure
        {
            get
            {
                return figure;
            }
            set
            {   // 1 - "10"
                if ((value >= '1' && value <= '9') || value == 'J' || value == 'Q' || value == 'K' || value == 'A') figure = value;
            }
        }
        public int Points
        {
            get
            {
                return points;
            }
            set
            {
                if (value >= 1 && value <= 11) points = value;
            }
        }
        public Colours Colour
        {
            get
            {
                return colour;
            }
            set
            {
                colour = value;
            }
        }
        public bool IsAce
        {
            get
            {
                return is_ace;
            }
            set
            {
                is_ace = value;
            }
        }
        public bool IsUsed
        {
            get
            {
                return is_used;
            }
            set
            {
                is_used = value;
            }
        }

        public Card(Bitmap image, string name, char figure, int points, Colours colour, bool is_ace)
        {
            this.image = image;
            this.name = name;
            this.figure = figure;
            this.points = points;
            this.is_ace = is_ace;
            this.is_used = false;
        }
    }
}
