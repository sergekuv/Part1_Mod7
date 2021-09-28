using System;
using System.Collections.Generic;

namespace Part1_Mod7
{
    static class IntExtensions
    {
        public static int GetNegative(this ref int x)   // Можно и не возвращать значение, а просто изменить значение параметра. 
                                                        // Сделаем и то, и другое
        {
            //return x = - Math.Abs(x);
            return  x = x > 0 ? -x : x;

        }
        public static int GetPositive(this ref int x)
        {
            return x = Math.Abs(x);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            //Task_7_1_4();
            //Task_7_1_5();
            //Task_7_1_6();
            //Task_7_1_10();
            //Task_7_2_3();       // Modified for 7.2.5
            //Task_7_2_7();
            //Task_7_2_12();
            //Task_7_2_14();
            //Task_7_3_3();
            //Task_7_5_2();
            //Task_7_5_3();
            //Task_7_5_5();
            Task_7_5_8();

            Console.WriteLine("-- End --");
        }

        #region Task_7_5_8
        private static void Task_7_5_8()
        {
            int i = 1;
            i.GetNegative();
            Console.WriteLine(i);
            Console.WriteLine(i.GetNegative());
            i.GetPositive();
            Console.WriteLine(i);
            int k = default;
            Console.WriteLine(k.GetNegative());
        }


        #endregion Task_7_5_8

        #region Task_7_5_5
        private static void Task_7_5_5()
        {
            throw new NotImplementedException();
        }

        class Obj755
        {
            public string name;
            public string description;

            public static string parent;
            public static int daysInWeek;
            public static int maxValue;

            static Obj755()
            {
                Console.WriteLine("Static ctr works");
                parent = "System.Object";
                daysInWeek = 7;
                maxValue = 2000;
            }
        }

        #endregion Task_7_5_5

        #region Task_7_5_3
        private static void Task_7_5_3()    // Создайте класс Helper и определите в нем статический метод Swap типа void,
                                            // который принимает 2 переменные типа int и меняет их значения местами.
        {
            int a = 1;
            int b = 2;
            Console.WriteLine(a + " " + b);
            Helper.Swap(ref a, ref b);
            Console.WriteLine(a + " " + b);
        }
        static class Helper
        {
            static Helper()
            {
                Console.WriteLine("Static Constructor works");
            }
            public static void Swap(ref int x, ref int y)
            {
                int z = x;
                x = y;
                y = z;
            }
        }

        #endregion Task_7_5_3

        #region Task_7_5_2
        private static void Task_7_5_2()    // Создайте класс Obj, определите в нем поля Name, Description (тип строки) и статическое поле MaxValue типа int, равное 2000.
        {
            Console.WriteLine($"Obj752.maxValue = {Obj752.maxValue}");
            Obj752 o = new Obj752();
            o.Display();
        }
        class Obj752
        {
            internal static int maxValue = 2000;
            string name;
            string description;
            public void Display()
            {
                Console.WriteLine(maxValue);
            }
        }

        #endregion Task_7_5_2

        #region Task_7_3_3  
        private static void Task_7_3_3()    // Создайте классы для следующих объектов компьютера: процессор (Processor), материнская карта (MotherBoard),
                                            // видеокарта (GraphicCard). Унаследуйте их от класса ComputerPart.
                                            // Добавьте в класс ComputerPart абстрактный метод Work без параметров и с типом void.
        {
            throw new NotImplementedException();
        }
        
        abstract class ComputerPart
        {
            string name;
            string description;
            decimal price;

            public ComputerPart(string name, string description, decimal price)
            {
                this.name = name;
                this.description = description;
                this.price = price;
            }
            public abstract void Work();
        }
        class MotherBoard : ComputerPart
        {
            public MotherBoard(string name, string description, decimal price) : base(name, description, price)
            {
            }
            public override void Work()
            {
                Console.WriteLine("z-z-z-z-");
            }
        }
        class Processor : ComputerPart
        {
            public Processor(string name, string description, decimal price) : base(name, description, price)
            {
            }
            public override void Work()
            {
                Console.WriteLine("zh-zh-zh-zh-");
            }
        }
        class GraphicBoard : ComputerPart
        {
            public GraphicBoard(string name, string description, decimal price) : base(name, description, price)
            {
            }
            public override void Work()
            {
                Console.WriteLine("sh-sh-sh-sh-");
            }
        }


        #endregion Task_7_3_3


        #region Task_7_2_14
        private static void Task_7_2_14()
        {
            IndexingClass ic = new IndexingClass();
            ic.Display();
            Item i = ic[1];
            i.Display();
            i = ic["one"];
            i.Display();
            ic[1] = i;
            ic["three"] = new Item { intPart = 10, stringPart = "ten" };
            ic.Display();
        }
        class Item
        {
            internal int intPart;
            internal string stringPart;
            public void Display()
            {
                Console.WriteLine($"{intPart}, {stringPart}");
            }
        }
        class IndexingClass
        {
            private string owner;
            private List<Item> collection;
            public IndexingClass()
            {
                owner = "owner";
                collection = new List<Item>();
                collection.Add(new Item { intPart = 1, stringPart = "one" });
                collection.Add(new Item { intPart = 2, stringPart = "two" });
                collection.Add(new Item { intPart = 3, stringPart = "three" });
            }
            public Item this[int index]
            {
                get
                {
                    foreach (Item i in collection)
                    {
                        if(i.intPart == index)
                        {
                            return i;
                        }
                    }
                    return null;
                }
                set
                {
                    if(index > 0 && index < collection.Count)
                    {
                        collection[index] = value;
                    }
                }
            }
            public Item this[string index]
            {
                get
                {
                    foreach (Item i in collection)
                    {
                        if (i.stringPart == index)
                        {
                            return i;
                        }
                    }
                    return null;
                }
                set
                {
                    for (int i =0; i < collection.Count; i++)
                    {
                        if (collection[i].stringPart == index)
                        {
                            collection[i] = value;
                            return;
                        }
                    }
                }
            }
            public void Display()
            {
                Console.WriteLine($"{owner}'s collection:");
                foreach(Item i in collection)
                {
                    Console.WriteLine($"{i.intPart}, {i.stringPart}");
                }
                Console.WriteLine();
            }
        }

        #endregion Task_7_2_14

        #region Task_7_2_12
        private static void Task_7_2_12()
        {
            Obj7212 o1 = new Obj7212 { value = 5 };
            Obj7212 o2 = new Obj7212 { value = 4 };
            Obj7212 o3 = o1 + o2;
            o3.Display();
        }
        class Obj7212
        {
            public int value;
            public static Obj7212 operator + (Obj7212 a, Obj7212 b)
            {
                Obj7212 o = new Obj7212();
                o.value = a.value + b.value;
                return o;
            }
            public static Obj7212 operator - (Obj7212 a, Obj7212 b)
            {
                Obj7212 o = new Obj7212();
                o.value = a.value - b.value;
                return o;
            }
            public void Display()
            {
                Console.WriteLine(value);
            }

        }

        #endregion Task_7_2_12

        #region Task_7_2_7
        private static void Task_7_2_7()    // Создайте схему классов A, B, C, D и E таким образом, чтобы B наследовался от A, С от A, D от B и E от C. А также:
                                            // Добавьте в класс A виртуальный метод Display(void тип, без параметров), который будет выводить в консоль "A".
                                            // В классе B скройте этот метод и сделайте так, чтобы в консоль выводилось "B".
                                            // Для класса C переопределите метод Display, чтобы в консоли было "C".
                                            // Для D снова скройте метод.
                                            // В классе E также скройте метод.
        {
            D d = new D();  
            E e = new E();
            d.Display();        //D
            ((A)e).Display();   //C
            ((B)d).Display();   //B
            ((A)d).Display();   //A
        }

        class A
        {
            public virtual void Display()
            {
                Console.WriteLine("A");
            }
        }
        class B : A
        {
            new public void Display()
            {
                Console.WriteLine("B (new)");
            }
        }
        class C : A
        {
            public override void Display()
            {
                Console.WriteLine("C (override)");
            }
        }
        class D : B
        {
            new public void Display()
            {
                Console.WriteLine("D (new)");
            }
        }
        class E : C
        {
            new public void Display()
            {
                Console.WriteLine("E (new)");
            }
        }

        #endregion Task_7_2_7

        #region Task_7_2_3
        private static void Task_7_2_3()    // Реализуйте в классе BaseClass виртуальный метод Display с типом void и без параметров,
                                            // который будет выводить сообщение "Метод класса BaseClass" в консоль,
                                            // а затем переопределите его в DerivedClass, чтобы он выводил сообщение "Метод класса DerivedClass".
        {
            BClass b = new BClass();
            b.Display();
            DClass d = new DClass();
            d.Display();
            BClass bd = new DClass();
            bd.Display();
            object o = new DClass();
            (o as BClass).Display();
            (o as DClass).Display();
        }

        class BClass
        {
            public virtual void Display()
            {
                Console.WriteLine("Base class method");
            }
        }
        class DClass : BClass
        {
            public override void Display()
            {
                base.Display();
                Console.WriteLine("Derived class method");
            }
        }

        #endregion Task_7_2_3


        #region Task_7_1_10
        private static void Task_7_1_10()   // Для класса DerivedClass создайте 2 конструктора:
                                            // один, принимающий 2 параметра — name и description,
                                            // второй — принимающий 3 параметра name, description и counter.
        {
            DerivedClass dc = new DerivedClass("NAME", "DESCR", 1);
            dc.Show();
        }
        class BaseClass
        {
            protected string name;

            public BaseClass(string name)
            {
                this.name = name;
            }
        }

        class DerivedClass : BaseClass
        {
            public string description;
            public int counter;
            DerivedClass(string name, string description) : base (name)
            {
                this.description = description;
            }
            internal DerivedClass(string name, string description, int counter) : this(name, description)
            {
                this.counter = counter;
            }
            public void Show()
            {
                Console.WriteLine($"Name: {name}, description: {description}, counter: {counter} ");
            }
        }

        #endregion Task_7_1_10

        #region _Task_7_1_6
        private static void Task_7_1_6()    // Реализуйте конструктор, заполняющий поля для следующего класса:
        {
            Console.WriteLine("PLease see required Employee/PM/Dev class descriptions in the code"); ;    //
        }
        class Obj
        {
            private string name;
            private string owner;
            private int length;
            private int count;

            public Obj(string name, string ownerName, int objLength, int count)
            {
                this.name = name;
                this.owner = ownerName;
                this.length = objLength;
                this.count = count;
            }
        }

        #endregion Task_7_1_6

        #region Task_7_1_5  
        private static void Task_7_1_5()  // Для следующего списка объектов создайте схему классов (объявите нужные классы и установите связи между ними):
                                          // Apple(яблоко); Banana(банан); Pear(груша); Potato(картофель); Carrot(морковь).
        {
            Console.WriteLine("PLease see required Employee/PM/Dev class descriptions in the code"); ;    //

        }
        class Food
        {
        }
        class Vegetable : Food
        {

        }
        class Fruit : Food
        {

        }
        class Apple : Fruit
        {

        }
        class Banana : Fruit
        {

        }
        class Pear : Fruit
        {

        }
        class Potato : Vegetable
        {

        }
        class Carrot : Vegetable
        {

        }
        #endregion Task_7_1_5

        #region Task_7_1_4
        private static void Task_7_1_4() // Задание 7.1.4
                                         // Для следующего класса Employee создайте 2 наследника: ProjectManager и Developer.
                                         // Класс ProjectManager должен содержать строковое поле ProjectName, а класс Developer — строковое поле ProgrammingLanguage.
        {
            Console.WriteLine("PLease see required Employee/PM/Dev class descriptions in the code"); ;    //
        }

        class Employee
        {
            public string name;
            public int age;
            public int salary;
        }
        class ProjectManager : Employee
        {
            string projectName;
        }
        class Developer : Employee
        {
            string programmingLanguage;
        }

        #endregion Task_7_1_4
    }
}
