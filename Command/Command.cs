//
// File Name : Command.cs
// Author : Yuan Sambo
// Author Email: yuan.sambo@gmail.com
// Date Created : 12/04/2020 
//


using System;
namespace Command
{
    // The command interface
    public interface Command
    {
        public void Execute();
    }

    // The receiver interface
    public interface Receiver
    {
        public void MoveRight();
        public void MoveLeft();
        public void MoveUp();
        public void MoveDown();
    }

    //Concrete receiver
    public class Character : Receiver
    {
        public void MoveDown()
        {
            Console.WriteLine("The player moved down");
        }

        public void MoveUp()
        {
            Console.WriteLine("The player moved up");
        }

        public void MoveLeft()
        {
            Console.WriteLine("The player moved left");
        }

        public void MoveRight()
        {
            Console.WriteLine("The player moved right");
        }
    }


    //Concrete commands
    public class RightCommand : Command
    {
        private readonly Character _character;

        public RightCommand(Character character)
        {
            _character = character;
        }


        public void Execute()
        {
            _character.MoveRight();
        }
    }
    public class LeftCommand : Command
    {
        private readonly Character _character;

        public LeftCommand(Character character)
        {
            _character = character;
        }


        public void Execute()
        {
            _character.MoveLeft();
        }
    }

    public class UpCommand : Command
    {
        private readonly Character _character;

        public UpCommand(Character character)
        {
            _character = character;
        }


        public void Execute()
        {
            _character.MoveUp();
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
            _character.MoveDown();
        }
    }
    // The invoker
    public class InputHandler
    {
        private readonly Character _character;


        public InputHandler(Character character)
        {
            _character = character;
        }


        private void InputHandling()
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

                while (true)
                {
                    inputHandler.InputHandling();
                }

            }
        }

    }
}