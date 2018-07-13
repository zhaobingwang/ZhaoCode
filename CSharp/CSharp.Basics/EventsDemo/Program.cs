using System;
using System.Collections.Generic;

namespace EventsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 事件Demo
            //Publisher pub = new Publisher();
            //Subscriber sub1 = new Subscriber("sub1", pub);
            //Subscriber sub2 = new Subscriber("sub2", pub);
            //pub.DoSomething(); 
            #endregion

            #region 在派生类中引发基类事件（C# 编程指南）
            Circle c1 = new Circle(54);
            Rectangle r1 = new Rectangle(12, 9);
            ShapeContainer sc = new ShapeContainer();

            sc.AddShape(c1);
            sc.AddShape(r1);
            c1.Update(57);
            r1.Update(7, 7);
            #endregion

            Console.Read();
        }
    }

    #region 事件Demo
    // Define a class to hold custom event info
    public class CustomEventArgs : EventArgs
    {
        public CustomEventArgs(string s)
        {
            Message = s;
        }
        public string Message { get; set; }
    }

    // Class that publishes an event
    class Publisher
    {
        public event EventHandler<CustomEventArgs> RaiseCustomEvent;
        public void DoSomething()
        {
            OnRaiseCustomEvent(new CustomEventArgs("Did something"));
        }

        protected virtual void OnRaiseCustomEvent(CustomEventArgs e)
        {
            EventHandler<CustomEventArgs> handler = RaiseCustomEvent;
            if (handler != null)
            {
                e.Message += $" at {DateTime.Now.ToString()}";
                handler(this, e);
            }
        }
    }

    class Subscriber
    {
        private string id;
        public Subscriber(string ID, Publisher pub)
        {
            id = ID;
            pub.RaiseCustomEvent += HandleCustomEvent;
        }
        void HandleCustomEvent(object sender, CustomEventArgs e)
        {
            Console.WriteLine($"{id} received this message: {e.Message}");
        }
    }
    #endregion


    #region 在派生类中引发基类事件（C# 编程指南）
    public class ShapeEventArgs : EventArgs
    {
        private double newArea;
        public ShapeEventArgs(double d)
        {
            newArea = d;
        }
        public double NewArea
        {
            get { return newArea; }
        }
    }
    public abstract class Shape
    {
        protected double area;
        public double Area
        {
            get { return area; }
            set { area = value; }
        }
        public event EventHandler<ShapeEventArgs> ShapeChanged;
        public abstract void Draw();

        protected virtual void OnShapeChanged(ShapeEventArgs e)
        {
            //EventHandler<ShapeEventArgs> handler = ShapeChanged;
            //if (handler != null)
            //{
            //    handler(this, e);
            //}
            ShapeChanged?.Invoke(this, e);
        }
    }
    public class Circle : Shape
    {
        private double radius;
        public Circle(double d)
        {
            radius = d;
            area = 3.14 * radius * radius;
        }
        public void Update(double d)
        {
            radius = d;
            area = 3.14 * radius * radius;
            OnShapeChanged(new ShapeEventArgs(area));
        }
        protected override void OnShapeChanged(ShapeEventArgs e)
        {
            base.OnShapeChanged(e);
        }
        public override void Draw()
        {
            Console.WriteLine("Drawing a circle");
        }
    }
    public class Rectangle : Shape
    {
        private double length;
        private double width;
        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
            area = length * width;
        }
        public void Update(double length, double width)
        {
            this.length = length;
            this.width = width;
            area = length * width;
            OnShapeChanged(new ShapeEventArgs(area));
        }
        protected override void OnShapeChanged(ShapeEventArgs e)
        {
            base.OnShapeChanged(e);
        }
        public override void Draw()
        {
            Console.WriteLine("Drawing a rectangle");
        }
    }
    public class ShapeContainer
    {
        List<Shape> _list;
        public ShapeContainer()
        {
            _list = new List<Shape>();
        }
        public void AddShape(Shape s)
        {
            _list.Add(s);
            s.ShapeChanged += HandleShapeChanged;
        }

        private void HandleShapeChanged(object sender, ShapeEventArgs e)
        {
            Shape s = (Shape)sender;
            Console.WriteLine($"收到消息，当前面积是：{e.NewArea}");
            s.Draw();
        }
    }
    #endregion
}
