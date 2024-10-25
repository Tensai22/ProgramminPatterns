using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice8.Mediator
{
    public interface IMediator
    {
        void SendMessage(string message, User user);
        void RegisterUser(User user);
    }

    public class ChatMediator : IMediator
    {
        private List<User> _users = new List<User>();

        public void RegisterUser(User user)
        {
            _users.Add(user);
        }

        public void SendMessage(string message, User sender)
        {
            foreach (var user in _users)
            {
                if (user != sender)
                {
                    user.ReceiveMessage(message);
                }
            }
        }
    }
    public abstract class User
    {
        protected IMediator mediator;
        protected string name;

        public User(IMediator mediator, string name)
        {
            this.mediator = mediator;
            this.name = name;
        }

        public abstract void Send(string message);
        public abstract void ReceiveMessage(string message);
    }

    public class ConcreteUser : User
    {
        public ConcreteUser(IMediator mediator, string name) : base(mediator, name) { }

        public override void Send(string message)
        {
            Console.WriteLine($"{name} sends: {message}");
            mediator.SendMessage(message, this);
        }

        public override void ReceiveMessage(string message)
        {
            Console.WriteLine($"{name} receives: {message}");
        }
    }

}
