using System;

namespace FlooringMastery.UI.WorkFlows
{
    public class MainMenu
    {
        public void Display()
        {
            Console.Clear();
            string input;
            DrawMenu();
            Console.Write($"Please choose an opion 1-5: ");

            do
            {
                input = "";
                input = Console.ReadLine();

                switch (input.ToUpper())
                {
                    case "1":
                        DisplayWorkFlow displayOrder = new DisplayWorkFlow();
                        break;
                    case "2":
                        //add an order
                        AddWorkFlow addOrder = new AddWorkFlow();  
                        break;
                    case "3":
                        //edit an order
                        EditWorkFlow editOrder = new EditWorkFlow();
                        break;
                    case "4":
                        //remove order
                        RemoveWorkflow remove = new RemoveWorkflow();
                        break;
                    case "5":
                        //quit
                        break;
                    default:
                        DrawMenu();
                        Console.WriteLine("You did something wrong...");
                        Console.Write($"Please choose an opion 1-5: ");
                        continue;
                }
            } while (input.ToUpper() != "Q");

        }

        void DrawMenu()
        {
            Console.Clear();
            Console.WriteLine("***********************************************");
            Console.WriteLine();
            Console.WriteLine("*               Flooring Program");
            Console.WriteLine();
            Console.WriteLine("*");
            Console.WriteLine();
            Console.WriteLine("* 1. Display Orders");
            Console.WriteLine();
            Console.WriteLine("* 2. Add an Order");
            Console.WriteLine();
            Console.WriteLine("* 3. Edit an Order");
            Console.WriteLine();
            Console.WriteLine("* 4. Remove an Order");
            Console.WriteLine();
            Console.WriteLine("* 5. Quit");
            Console.WriteLine();
            Console.WriteLine("*");
            Console.WriteLine();
            Console.WriteLine("***********************************************");
            Console.WriteLine();
        }
    }
}

