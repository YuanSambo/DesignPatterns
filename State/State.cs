//
// File Name : State.cs
// Author : Yuan Sambo
// Author Email: yuan.sambo@gmail.com
// Date Created : 29/04/2020
//

using System;

namespace State
{
    public abstract class State
    {
        protected Context _context;

        public void SetContext(Context context)
        {
            _context = context;
        }

        public abstract void DoSomething1();
        public abstract void DoSomething2();

    }

    public class ConcreteStateA : State
    {
        public override void DoSomething1()
        {
            Console.WriteLine("Done something 1 by ConcreteState A ");
            _context.SetState(new ConcreteStateB());

        }

        public override void DoSomething2()
        {
            Console.WriteLine("Done something 2 by ConcreteState A ");
            _context.SetState(new ConcreteStateB());

        }

    }

    public class ConcreteStateB : State
    {
        public override void DoSomething1()
        {
            Console.WriteLine("Done something 1 by ConcreteState B ");
            _context.SetState(new ConcreteStateA());

        }

        public override void DoSomething2()
        {
            Console.WriteLine("Done something 2 by ConcreteState B ");
            _context.SetState(new ConcreteStateA());

        }

    }

    public class Context
    {
        private State _state;

        public void SetState(State state)
        {
            _state = state;
            state.SetContext(this);
        }

        public void Request1()
        {
            _state.DoSomething1();
        }

        public void Request2()
        {
            _state.DoSomething2();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
          Context context = new Context();
          context.SetState(new ConcreteStateA());
          context.Request1();
          context.SetState(new ConcreteStateB());
          context.Request2();
        }
    }
}

