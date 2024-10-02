namespace Name
{
    class Program
    {
        public static void Main(){
            Circle circ = new(5);

            Square squ = new(8);

            Console.WriteLine(circ.CalculateArea());
            Console.WriteLine(squ.CalculateArea());
        }
    }
    public class Circle{
        private double _radius;

        public Circle(double radius)
        {
            _radius = radius;
        }

        public double CalculateArea()
        {
            return Math.PI * _radius * _radius;
        }
    }

    public class Square{
        private double _side;

        public Square(double side)
        {
           _side = side;
        }

        public double CalculateArea()
        {
           return _side * _side;
        }
    }


}