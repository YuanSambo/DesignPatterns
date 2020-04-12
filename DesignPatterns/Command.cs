//
// File Name : Command.cs
// Author : Yuan Sambo
// Author Email: yuan.sambo@gmail.com
// Date Created : 12/04/2020 
//


using System;
namespace DesignPatterns
{
    // The command interface
    public interface Command
    {
        public void Execute();
    }

    // The receiver interface
    public interface Receiver
    {
        public void moveRight();
        public void moveLeft();
        public void moveUp();
        public void moveDown();
    }

    //Concrete receiver
    public class Character : Receiver
    {
        public void moveDown()
        {
            Console.WriteLine("The player moved down");
        }

        public void moveUp()
        {
            Console.WriteLine("The player moved up");
        }

        public void moveLeft()
        {
            Console.WriteLine("The player moved left");
        }

        public void moveRight()
        {
            Console.WriteLine("The player moved right");
        }
    }


    //Concrete commands
    public class RightCommand : Command
    {
        Character _character;

        public RightCommand(Character character)
        {
            _character = character;
        }


        public void Execute()
        {
            _character.moveRight();
        }
    }
    public class LeftCommand : Command
    {
        Character _character;

        public LeftCommand(Character character)
        {
            _character = character;
        }


        public void Execute()
        {
            _character.moveLeft();
        }
    }

    public class UpCommand : Command
    {

        Character _character;

        public UpCommand(Character character)
        {
            _character = character;
        }


        public void Execute()
        {
            _character.moveUp();
        }
    }


    public class DownCommand : Command
    {

        Character _character;

        public DownCommand(Character character)
        {
            _character = character;
        }


        public void Execute()
        {
            _character.moveDown();
        }
    }
    // The invoker
    public class InputHandler
    {
        Character _character;


        public InputHandler(Character character)
        {
            _character = character;
        }



        public void InputHandling()
        {
            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.W) { new UpCommand(_character).Execute();}
            if (key == ConsoleKey.S) { new DownCommand(_character).Execute();}
            if (key == ConsoleKey.A) { new LeftCommand(_character).Execute(); }
            if (key == ConsoleKey.D) { new RightCommand(_character).Execute(); }
        }


        public class Game
        {
            static void Main(String[] args)
            {
                Character player1 = new Character();
                InputHandler inputHandler = new InputHandler(player1);
                Boolean GameisRunning = true;

                while (GameisRunning)
                {
                    inputHandler.InputHandling();
                }

            }
        }

    }
}