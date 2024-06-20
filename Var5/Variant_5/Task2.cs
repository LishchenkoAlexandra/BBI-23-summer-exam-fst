using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Variant_5
{

    public class Task2
    {

        private Embrasure[] embrasures;
        public Embrasure[] Embrasures => embrasures;

        public Task2(Embrasure[] embrasures)
        {
            this.embrasures = embrasures;
        }

        public void Sorting()
        {
            Array.Sort(embrasures, (e1, e2) => e1.Cost().CompareTo(e2.Cost()));
        }

        public abstract class Rectangle
        {
            protected int a;
            protected int b;
            protected int c;

            protected Rectangle(int a, int b, int c)
            {
                this.a = Math.Max(a, 0);
                this.b = Math.Max(b, 0);
                this.c = Math.Max(c, 0);
            }

            public int A => a;
            public int B => b;
            public int C => c;

            public int Length() => 2 * (a + b);
            public int Area() => a * b;

            public abstract double Cost();
            public override string ToString() => $"Type = {GetType().Name}, p = {Length()}, s = {Area()}, price = {Cost()}";
        }

        public abstract class Embrasure : Rectangle
        {
            protected Embrasure(int a, int b, int c) : base(a, b, c)
            {
            }

            public override double Cost() => Area() * 10;
        }

        public class Window : Embrasure
        {
            public int Layers { get; private set; }

            public Window(int a, int b, int c, int layers) : base(a, b, c)
            {
                Layers = Math.Max(layers, 0);
            }

            public override double Cost() => base.Cost() + (Layers * 100); 
        }

        public class Door : Embrasure
        {
            public string Material { get; private set; }

            public Door(int a, int b, int c, string material) : base(a, b, c)
            {
                Material = material;
            }

            public override double Cost()
            {
                double baseCost = Area() * 10; 
                double multiplier = Material switch
                {
                    "пластик" => 1.25,
                    "дерево" => 1.33,
                    _ => 1.0,
                };
                return baseCost * multiplier;
            }
        }
    }
}
