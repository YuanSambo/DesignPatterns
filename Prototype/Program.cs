using System;

namespace Prototype
{
    
    public class Enemy
    {
        public string name;
        public int damage;
        
        public Enemy(String name , int damage)
        {
            this.name = name;
            this.damage = damage;
        }

        public Enemy Clone()
        {
            return (Enemy)this.MemberwiseClone();
        }
      
        public override string ToString()
        {
            return $"Name : {name} . Damage{damage}";
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
           Enemy RedSlime = new Enemy("Slimey",10);
           Enemy GreenSlime= RedSlime.Clone();

           Console.WriteLine(RedSlime);
           Console.WriteLine(GreenSlime);

        }
    }
}