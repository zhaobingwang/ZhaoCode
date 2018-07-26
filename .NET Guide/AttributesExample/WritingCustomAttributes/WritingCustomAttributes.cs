using System;

namespace WritingCustomAttributes
{
    [Developer("Route8", "1", Reviewed = true)]
    class WritingCustomAttributes
    {
        static void Main(string[] args)
        {
            GetAttribute(typeof(WritingCustomAttributes));
        }
        static void GetAttribute(Type t)
        {
            DeveloperAttribute MyAttribute = (DeveloperAttribute)Attribute.GetCustomAttribute(t, typeof(DeveloperAttribute));

            if (MyAttribute == null)
            {
                Console.WriteLine("The attribute was not found.");
            }
            else
            {
                Console.WriteLine("The Name Attribute is: {0}.", MyAttribute.Name);
                Console.WriteLine("The Level Attribute is: {0}.", MyAttribute.Level);
                Console.WriteLine("The Reviewed Attribute is: {0}.", MyAttribute.Reviewed);
            }
        }
    }


    [AttributeUsage(AttributeTargets.All)]
    public class DeveloperAttribute : Attribute
    {
        private string name;
        private string level;
        private bool reviewed;

        public DeveloperAttribute(string name, string level)
        {
            this.name = name;
            this.level = level;
            this.reviewed = false;
        }

        public virtual string Name
        {
            get { return name; }
        }

        public virtual string Level
        {
            get { return level; }
        }

        public virtual bool Reviewed
        {
            get { return reviewed; }
            set { reviewed = false; }
        }
    }
}
