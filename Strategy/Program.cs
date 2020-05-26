//
// File Name : Strategy.cs
// Author : Yuan Sambo
// Author Email: yuan.sambo@gmail.com
// Date Created : 29/04/2020
//

using System;

namespace Strategy
{
    public interface IJob
    {
        public void Attack();
    }

    public class Warrior : IJob
    {
        public void Attack()
        {
            Console.WriteLine("Deals Physical attacks !");
        }
    }
    
    public class Mage : IJob
    {
        public void Attack()
        {
            Console.WriteLine("Deals Magic attack !");
        }
    }

    public class Player
    {
        private IJob _job;

        public Player(IJob job)
        {
            _job = job;
        }
        public void Attack()
        {
            _job.Attack();
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Player Zilong = new Player(new Warrior());
            Player Eudora = new Player(new Mage());
            Zilong.Attack();
            Eudora.Attack();

        }
    }
}