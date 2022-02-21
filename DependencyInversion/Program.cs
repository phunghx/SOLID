using System;
using System.Collections.Generic;
using System.Linq;

namespace DependencyInversion
{
    class Program
    {
        public enum Relationship
        {
            Parent, Child, Sibling
        }
        public class Person
        {
            public string Name { set; get; }
        }
        public interface IAdder
        {
            public void AddParentAndChildren(Person parent, Person child);
        }
        public interface IRelationShip
        {
            public IEnumerable<Person> FindAllChildOf(string name);
        }
        public interface IRelationAdder : IAdder, IRelationShip
        {

        }
        
        public class RelationShipFamily : IRelationAdder
        {
            private List<(Person, Relationship, Person)> relations
                = new List<(Person, Relationship, Person)>();
            public void AddParentAndChildren(Person parent,Person child)
            {
                relations.Add((parent, Relationship.Parent, child));
                relations.Add((child, Relationship.Child, parent));
            }
            public List<(Person, Relationship, Person)> Relations => relations;
            public IEnumerable<Person> FindAllChildOf(string name)
            {
                return relations
                    .Where(x => x.Item1.Name == name && x.Item2 == Relationship.Parent)
                    .Select(y => y.Item3);
            }
        }
        public class Explorer
        {
            public void findRelationParent(IRelationShip relationshipfamily)
            {
                //foreach (var p in
                //    relationshipfamily.Relations
                //    .Where(x => x.Item1.Name == "Phung" && x.Item2 == Relationship.Parent))
                //{
                //    Console.WriteLine($"Phung has a child call {p.Item3.Name}");
                //}

                foreach (var p in relationshipfamily.FindAllChildOf("Phung"))
                {
                    Console.WriteLine($"Phung has a child call {p.Name}");
                }
            }
        }
        static void Main(string[] args)
        {
            IRelationAdder relationshipfamily = new RelationShipFamily();
            relationshipfamily.AddParentAndChildren(new Person { Name = "Phung" },
                                      new Person { Name = "Nhat" });
            relationshipfamily.AddParentAndChildren(new Person { Name = "Phung" },
                                      new Person { Name = "Ha" });
            Explorer exp = new Explorer();
            exp.findRelationParent(relationshipfamily);
        }
    }
}
