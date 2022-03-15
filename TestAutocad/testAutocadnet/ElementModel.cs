﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testAutocadnet
{
    public class ElementModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Blockname { get; set; }
        public Point InitialPoint { get; set; }
        public Point EndPoint { get; set; }
        public double Rotation { get; set; }
        public double Depth { get; set; }
        public double Length { get; set; }
        public string Matirial    { get; set; }
        public class Point {
            public double X { get; set; }
            public double Y { get; set; }

            public Point(double y, double x)
            {
                X = x;
                Y = y;

            }

        }

        public int RotationToDegree(double radians)
        {           
            return  (int) Math.Round( (180 / Math.PI) * radians);
        }
        public int Rotation_Degree()
        {
            return (int)Math.Round((180 / Math.PI) * Rotation);
        }

        public double inchToFeet(double num) 
        {
            return (double)(num * 0.0833333);

        }

        public double Length_feet()
        {
            return (double)(Length * 0.0833333);

        }

        public double Depth_feet()
        {
            return (double)(Depth * 0.0833333);

        }
    }
}
