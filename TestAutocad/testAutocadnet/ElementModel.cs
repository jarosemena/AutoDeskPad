using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testAutocadnet
{
    public class ElementModel
    {
        public ElementModel()
        {
            this.ID = "-1";
            this.ObjID = ObjectId.Null;
            this.Name = "";
            this.Blockname = "";
            this.InitialPoint = new ElementModel.Point(0, 0); 
            this.Rotation = 0;
            this.Matirial = "";
            this.EndPoint = new ElementModel.Point(0, 0);
            this.Depth = 0;
            this.Length = 0;
        }
        public string ID { get; set; }
        public ObjectId ObjID { get; set; }
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

            public string Text()
            {
                
                    return X.ToString() + "," + Y.ToString();

            }

            public void append(string point)
            {
                if (point == null && point.Contains(","))
                {
                    this.X = Convert.ToDouble(point.Split(',')[0]);
                    this.Y = Convert.ToDouble(point.Split(',')[1]);
                }
                else
                {
                    this.X = 0;
                    this.Y = 0;
                }
                
            }
        }

        public int RotationToDegree(double radians)
        {           
            return  (int) Math.Round( (180 / Math.PI) * radians);
        }

        public int DegreeToRotation(double radians)
        {
            return (int)Math.Round((Math.PI / 180) * radians);
        }

        public int Rotation_Degree()
        {
            return (int)Math.Round((180 / Math.PI) * Rotation);
        }

    
        public double InchToFeet(double num) 
        {
            return (double)(num * 0.0833333);

        }

        public double FeetToInch(double num)
        {
            return (double)(num * 12);

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
