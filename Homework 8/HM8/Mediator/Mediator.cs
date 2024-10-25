using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM8.Mediator
{
    public interface IMediator
    {
        void RegisterUser(User user);
        void SendMessage(string message, User sender);
    }

    public class ChatRoom : IMediator
    {
        private List<User> _users = new List<User>();

        public void RegisterUser(User user)
        {
            _users.Add(user);
            Console.WriteLine($"{user.Name} joined to chat.");
        }

        public void SendMessage(string message, User sender)
        {
            foreach (var user in _users)
            {
                if (user != sender)
                {
                    user.Receive(message, sender);
                }
            }
        }
    }

    public abstract class User
    {
        protected IMediator _mediator;
        public string Name { get; private set; }

        public User(IMediator mediator, string name)
        {
            _mediator = mediator;
            Name = name;
        }

        public abstract void Receive(string message, User sender);
        public void Send(string message)
        {
            Console.WriteLine($"{Name} sends: {message}");
            _mediator.SendMessage(message, this);
        }
    }

    public class ConcreteUser : User
    {
        public ConcreteUser(IMediator mediator, string name) : base(mediator, name) { }

        public override void Receive(string message, User sender)
        {
            Console.WriteLine($"{Name} received from {sender.Name}: {message}");
        }
    }
}
