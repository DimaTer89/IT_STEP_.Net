using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_1
{
    class Circle
    {
        double coordinate_X;
        double coordinate_Y;
        double radius;
        public Circle()
        {
            coordinate_X = coordinate_Y = 0;
            radius = 1;
        }
        public Circle(int x, int y, double l)
        {
            coordinate_X = x;
            coordinate_Y = y;
            radius = l;
        }
        public double Coordinate_X
        {
            get
            {
                return coordinate_X;
            }
            set
            {
                coordinate_X = value;
            }
        }
        public double Coordinate_Y
        {
            get
            {
                return coordinate_Y;
            }
            set
            {
                coordinate_Y = value;
            }
        }
        public double Radius
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value;
            }
        }
        public double Сircumference
        {
            get
            {
                return ((double)(3.14 * 2 * radius));
            }
        }
        public override string ToString()
        {
            return ($"({coordinate_X};{coordinate_Y})");
        }
        public bool fourth()
        {
            if (coordinate_X < 0 && coordinate_Y < 0)
            {
                if ((radius + coordinate_X) <= 0 && (radius + coordinate_Y) <= 0)
                    return true;
                else
                    return false;
            }
            if (coordinate_X<0||coordinate_Y<0)
            {
                if(coordinate_X<0)
                {
                    if ((radius + coordinate_X) <= 0 && radius <= coordinate_Y)
                        return true;
                    else
                        return false;
                }
                else
                {
                    if (radius <= coordinate_X && (radius + coordinate_Y) <= 0)
                        return true;
                    else
                        return false;
                }
            }
            
            else
            {
                if (radius <= coordinate_X && radius <= Coordinate_Y)
                    return true;
                else
                    return false;
            }
        } 
        public void ChangeRad(double num)
        {
            radius+= num;
        }
        public static bool intersectionOfCircles(Circle circle1, Circle circle2)
        {
            double num = (circle1.Coordinate_X - circle2.Coordinate_X)*(circle1.Coordinate_X-circle2.Coordinate_X) +(circle1.Coordinate_Y - circle2.Coordinate_Y)*(circle1.Coordinate_Y-circle2.Coordinate_Y);
            if (Math.Sqrt(num) < (circle1.Radius + circle2.Radius) && Math.Sqrt(num) > Math.Abs(circle1.Radius - circle2.Radius))
                return true;
            else
                return false;
        }
        public void move(int x = 0,int y=0)
        {
            coordinate_X += x;
            coordinate_Y += y;
        }
    }
}
