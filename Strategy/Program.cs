//
// File Name : Strategy.cs
// Author : Yuan Sambo
// Author Email: yuan.sambo@gmail.com
// Date Created : 29/04/2020
//

using System;

namespace Strategy
{
    public interface IAttack
    {
        public void Attack();
    }

    public class PhysicalAttack : IAttack
    {
        public void Attack()
        {
            Console.WriteLine("Deals Physical attacks !");
        }
    }
    
    public class MagicAttack : IAttack
    {
        public void Attack()
        {
            Console.WriteLine("Deals Magic attack !");
        }
    }

    public class Player
    {
        public void Attack(IAttack attack)
        {
            attack.Attack();
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player();
            player1.Attack(new PhysicalAttack());
            player1.Attack(new MagicAttack());
        }
    }
}