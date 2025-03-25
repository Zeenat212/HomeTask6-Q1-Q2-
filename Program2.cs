using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask6_Q2_
{
   
        public class Shape
        {
            private int shapeID;
            private string shapeType;
            private string colour;

            //Properties
            public int ID_of_Shape
            {
                get { return shapeID; }
                set { shapeID = value; }
            }
            public string Type_of_Shape
            {
                get { return shapeType; }
                set { shapeType = value; }
            }
            public string Colour_of_Shape
            {
                get { return colour; }
                set { colour = value; }
            }
            public Shape(int shapeID, string shapeType, string colour)
            {
                this.shapeID = shapeID;
                this.shapeType = shapeType;
                this.colour = colour;

            }
            //Overloading Constructor for deep Copy
            public Shape(Shape other)
            {
                shapeID = other.shapeID;
                shapeType = other.shapeType;
                colour = other.colour;
            }

            //Method to draw a shape

            public void Draw()
            {
                Console.WriteLine($"Shape ID : {shapeID},Shape Type :{shapeType},Colour :{colour}");
            }

            //Destructor

            ~Shape()
            {
                Console.WriteLine($"Shape with Id {shapeID} is Terminated ");
            }
        }
        public class Canvas
        {
        private int canvasId;
        private Shape[] shapes;
        private int ShapeCount;

        //property
        public int ID_of_canvas
            { get { return canvasId; } set { canvasId = value; } }
        //Constructor
        public Canvas(int Id)
        {
            canvasId = Id;
            shapes = new Shape[10];
            ShapeCount = 0;
        }
        //Constructor Overloading for deep copy
        public Canvas(Canvas other)
        {
            this.canvasId = other.canvasId;
            this.ShapeCount = other.ShapeCount;
            shapes = new Shape[10];
            for (int i = 0; i < ShapeCount; i++)
            {
                this.shapes[i] = other.shapes[i];
            }
        } 
        public void AddShape(Shape shape)
        {
            if (ShapeCount < shapes.Length)
            {
                shapes[ShapeCount++] = shape;
            }
            else
            {
                Console.WriteLine("List full");
            }
        }
        public void DisplayShapes()
        {
            Console.WriteLine($"All shapes in Canvas {canvasId} are: ");
            for (int i = 0;i < ShapeCount;i++)
            {
                shapes[i].Draw();
            }
        }
        ~Canvas()
        {
            Console.WriteLine($"Objects of canvas {canvasId} is killed");
           
        }
        }
        internal class Program
        {
            static void Main(string[] args)
            {
            Shape s1 = new Shape(1,"Circle","Red");
            Shape s2 = new Shape(2,"Triangle ","Yellow");
            Shape Original_Shape = new Shape(3, "Square", "Blue");

            //Shallow
            Shape Shallow_Shape=Original_Shape;

            //Deep
            Shape Deep_Shape = new Shape(Original_Shape);
            //Before Changes
            Console.WriteLine("Before Changes");
            Original_Shape.Draw();

            Console.WriteLine("Shallow copy Changes shapes");
            Shallow_Shape.Draw();

            Console.WriteLine("Deep Copy of Shapes");
            Deep_Shape.Draw();

            //Changes Shape

            Original_Shape.ID_of_Shape = 5;
            Original_Shape.Type_of_Shape = "Cube";
            Original_Shape.Colour_of_Shape = "White";

            //After Changes
            Console.WriteLine("**************************************************");
            Console.WriteLine("After Changes");
            Original_Shape.Draw();

            Console.WriteLine("After Shallow copy Changes shapes");
            Shallow_Shape.Draw();

            Console.WriteLine("After Deep Copy of Shapes");
            Deep_Shape.Draw();
            Console.ReadLine();
            Console.Clear();

            //Canvas object
            Canvas c1 =new Canvas(1);
            Canvas Original_Canvas = new Canvas(2);

            //Add Shapes
            Original_Canvas.AddShape(s1);
            Original_Canvas.AddShape(s2);

            //Shallow Copy
            Canvas Shallow_Canvas = Original_Canvas;

            //Deep Copy
            Canvas Deep_Canvas = new Canvas(Original_Canvas);

            //Display
            Console.WriteLine("Original Values");
            Original_Canvas.DisplayShapes();

            Console.WriteLine("Shallow Canvas befor Changes");
            Shallow_Canvas.DisplayShapes();
        
            Console.WriteLine("Deep Canvas befor Changes");
            Deep_Canvas.DisplayShapes();

            //Changes
            Original_Canvas.ID_of_canvas = 15;
            Original_Canvas.AddShape(Original_Shape);

            //Display
            Console.WriteLine("**********************************************");
            Console.WriteLine("Original Values After Changes ");
            Original_Canvas.DisplayShapes();

           
            Console.WriteLine("Shallow Canvas After Changes");    
            Shallow_Canvas.DisplayShapes();

            Console.WriteLine("Deep Canvas After Changes");       
            Deep_Canvas.DisplayShapes();

            Console.ReadLine();
        }

        }
    }
