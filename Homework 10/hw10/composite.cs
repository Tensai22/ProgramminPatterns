using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw10
{
    public abstract class FileSystemComponent
    {
        public string Name { get; protected set; }

        public FileSystemComponent(string name)
        {
            Name = name;
        }

        public abstract void Display(int depth = 0);
        public abstract int GetSize();
    }
    public class File : FileSystemComponent
    {
        private readonly int size;

        public File(string name, int size) : base(name)
        {
            this.size = size;
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string(' ', depth * 2) + $"- {Name} (File, {size}KB)");
        }

        public override int GetSize() => size;
    }
    public class Directory : FileSystemComponent
    {
        private readonly List<FileSystemComponent> components = new List<FileSystemComponent>();

        public Directory(string name) : base(name) { }

        public void Add(FileSystemComponent component)
        {
            if (!components.Contains(component))
            {
                components.Add(component);
                Console.WriteLine($"Added {component.Name} to {Name}");
            }
        }

        public void Remove(FileSystemComponent component)
        {
            if (components.Contains(component))
            {
                components.Remove(component);
                Console.WriteLine($"Removed {component.Name} from {Name}");
            }
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string(' ', depth * 2) + $"+ {Name} (Directory)");
            foreach (var component in components)
            {
                component.Display(depth + 1);
            }
        }

        public override int GetSize()
        {
            return components.Sum(c => c.GetSize());
        }
    }

}
