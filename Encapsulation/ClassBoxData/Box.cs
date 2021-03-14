using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private decimal length;
        private decimal width;
        private decimal height;

        public Box(decimal length, decimal width, decimal height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public decimal Length
        {
            get => this.length;
            private set
            {

                ThrowIfInvalid(value, nameof(Length));

                this.length = value;
            }
        }

        public decimal Width
        {
            get => this.width;
            private set
            {
                ThrowIfInvalid(value, nameof(Width));

                this.width = value;
            }
        }
        public decimal Height
        {
            get => this.height;
            private set
            {
                ThrowIfInvalid(value, nameof(Height));

                this.height = value;
            }
        }

        public decimal CalculateVolume()
        {
            return Length * Width * Height;
        }

        public decimal CalculateSurfaceArea()
        {
            return 2 * Length * Width + 2 * Length * Height + 2 * Width * Height;
        }

        public decimal CalculateLeteralArea()
        {
            return 2 * Length * Height + 2 * Width * Height;
        }

        private void ThrowIfInvalid(decimal side, string name)
        {
            if(side <= 0)
            {
                throw new ArgumentException($"{name} cannot be zero or negative.");
            }
        }
    }
}
