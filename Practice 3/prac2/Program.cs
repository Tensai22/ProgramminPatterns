using System;
using System.Collections.Generic;


namespace Name
{
    class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User("yrtensai", "tensai@gmail.com", "Admin");
            User user2 = new User("odetari", "odetari@gmail.com", "User");
            User user3 = new User("senjumaru", "senjumaru@gmail.com", "User");
            User user4 = new User("khngldi", "khngldi@gmail.com", "User");
            User user5 = new User("bruh", "brubruh@gmail.com", "Moderator");
            UserManager clients = new UserManager();
            clients.AddUser(user1);
            clients.AddUser(user2);
            clients.AddUser(user3);
            clients.AddUser(user4);
            clients.AddUser(user5);
            clients.ShowAllUsers();
            clients.UpdateUser(user1, name: "Tensai");
            clients.UpdateUser(user2, role: "Guest");
            clients.UpdateUser(user5, name: "nurik@gmail.com");
            clients.ShowAllUsers();

            Console.ReadKey();
        }
    }

    public class User
    {
        public string name;
        public string email;
        public string role;

        public User(string name, string email, string role)
        {
            this.name = name;
            this.email = email;
            this.role = role;
        }
    }
    public class UserManager{

            List<User> users = new();

            public void AddUser(User user){
                users.Add(user);
            } 
            public void RemoveUser(User user){
                users.Remove(user);
            }
            public void UpdateUser(User user, string? name = null, string? email = null, string? role = null){
                if (name != null)
                {
                    user.name = name;
                }
                if (email != null)
                {
                    user.email = email;
                }
                if (role != null)
                {
                    user.role = role;
                }
            }
            public void ShowAllUsers(){
                foreach (var user in users)
                {
                    Console.WriteLine($"Username: {user.name}, email: {user.email}, role: {user.role}");
                }
            }

    }
}
