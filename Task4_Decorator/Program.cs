using System;
using System.Text;

namespace Decorator
{
    class Program
    {
        public abstract class ChristmasTree
        {
            public abstract void Display();
        }

        public class SimpleChristmasTree : ChristmasTree
        {
            public override void Display()
            {
                Console.WriteLine("Звичайна зелена ялинка.");
            }
        }

        public abstract class TreeDecorator : ChristmasTree
        {
            protected ChristmasTree? tree;

            public void SetTree(ChristmasTree baseTree)
            {
                tree = baseTree;
            }

            public override void Display()
            {
                if (tree != null)
                {
                    tree.Display();
                }
            }
        }

        public class OrnamentsDecorator : TreeDecorator
        {
            public string Ornaments { get; set; } = "Червоні кульки та зірка";

            public override void Display()
            {
                base.Display();
                Console.WriteLine($" + Прикрашена іграшками: {Ornaments}.");
            }
        }

        public class GarlandDecorator : TreeDecorator
        {
            public override void Display()
            {
                base.Display();
                Glow();
            }

            public void Glow()
            {
                Console.WriteLine(" + На ялинці увімкнено гірлянду: Ялинка світиться яскравими вогниками!");
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            ChristmasTree tree = new SimpleChristmasTree();
            OrnamentsDecorator treeWithOrnaments = new OrnamentsDecorator();
            GarlandDecorator festiveTree = new GarlandDecorator();

            treeWithOrnaments.Ornaments = "Золоті кульки, шишки та верхівка-зірка";
            treeWithOrnaments.SetTree(tree);

            festiveTree.SetTree(treeWithOrnaments);
            festiveTree.Display();
        }
    }
}
