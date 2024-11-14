using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Practice_10.Program;

namespace Practice_10
{
    public class Employee : OrganizationComponent
    {
        public override void Add(OrganizationComponent component)
        {
            throw new NotImplementedException();
        }
        public override void Remove(OrganizationComponent component)
        {
            throw new NotImplementedException();
        }
    }
    public class Department : OrganizationComponent
    {
        private List<OrganizationComponent> components;
        public override void Add(OrganizationComponent component)
        {
            components.Add(component);
        }
        public override void Remove(OrganizationComponent component)
        {
            components.Remove(component);
        }
        public double GetSalary()
        {
            return components.Sum(component => component.salary);
        }
        public int GetCount()
        {
            return components.Count();
        }
    }
}
