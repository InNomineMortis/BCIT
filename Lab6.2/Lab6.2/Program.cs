using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Lab62
{
    class Program
    {
        /// <summary>
        /// property has attribute of this type 
        /// </summary>
        /// <returns>Attribute Value</returns>
        public static bool GetPropertyAttribute(PropertyInfo checkType, Type
       attributeType, out object attribute)
        {
            bool Result = false;
            attribute = null;
            //Search of attributes wiht different types
            var isAttribute = checkType.GetCustomAttributes(attributeType, false);
            if (isAttribute.Length > 0)

            {
                Result = true;
                attribute = isAttribute[0];
            }
            return Result;
        }

        static void Main(string[] args)
        {
            ForInspection obj = new ForInspection();
            Type t = obj.GetType();
            Console.WriteLine("\nType information:");   //Type
            Console.WriteLine("Type " + t.FullName + " inherited from " + t.BaseType.FullName); //Inheritance
            Console.WriteLine("\nNamespace" + t.Namespace); //Namespace
            Console.WriteLine("Assembled in " + t.AssemblyQualifiedName);      //Assembly
            Console.WriteLine("\nConstructors :"); //Constructors
            foreach (var x in t.GetConstructors())
            { Console.WriteLine(x); }
            Console.WriteLine("\nMethods:");    //Methods
            foreach (var x in t.GetMethods())
            { Console.WriteLine(x); }
            Console.WriteLine("\nProperties:"); //Properties
            foreach (var x in t.GetProperties())
            { Console.WriteLine(x); }
            Console.WriteLine("\nData fields (public):");   //Data
            foreach (var x in t.GetFields())
            { Console.WriteLine(x); }
            Console.WriteLine("\nForInspection contains IComparable -> " + t.GetInterfaces().Contains(typeof(IComparable)));    //Interface
            Console.WriteLine("\nProperties with attributes:"); //Attributes
            foreach (var x in t.GetProperties())
            {
                object attrObj;
                if (GetPropertyAttribute(x, typeof(NewAttribute), out attrObj))
                {
                    NewAttribute attr = attrObj as NewAttribute;
                    Console.WriteLine(x.Name + " - " + attr.Description);
                }
            }
            Console.WriteLine("\nMethod use :");    //Method call
     
            //Reflection object creation
            ForInspection fi = (ForInspection)t.InvokeMember(null,
           BindingFlags.CreateInstance, null, null, new object[] { });
            //Method call properties
            object[] parameters = new object[] { 3, 2 };

            //Method call
            object Result = t.InvokeMember("Plus", BindingFlags.InvokeMethod,
           null, fi, parameters);
            Console.WriteLine("Plus(3,2)={0}", Result);
            Console.ReadLine();
        }
    }
    /// <summary> 
    /// Reflection iheritance class
    /// </summary>
    public class ForInspection : IComparable
    {
        public ForInspection() { }
        public ForInspection(int i) { }
        public ForInspection(string str) { }
        public int Plus(int x, int y) { return x + y; }
        public int Minus(int x, int y) { return x - y; }
        [NewAttribute("property1 description")]
        public string property1
        {
            get { return _property1; }
            set { _property1 = value; }
        }
        private string _property1;
        public int property2 { get; set; }
        [NewAttribute(Description = "property3 description")]
        public double property3 { get; private set; }
        public int field1;
        public float field2;
        /// <summary> 
        /// Interface IComparable realization
        /// </summary> 
        public int CompareTo(object obj) { return 0; }
    }
    /// <summary>
    /// Attribute class
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false,
   Inherited = false)]
    public class NewAttribute : Attribute
    {
        public NewAttribute() { }
        public NewAttribute(string DescriptionParam)
        {
            Description = DescriptionParam;
        }
        public string Description { get; set; }
    }

}


