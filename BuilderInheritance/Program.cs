using System;

namespace Creational.BuilderInheritance
{
    public class Person
    {
        public string Name;

        public string Position;

      public  class Builder : PersonJobBuilder<Builder> { /* degenerate */ }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }

        public static Builder New => new Builder();
    }

   public abstract class PersonBuilder<SELF>
      where SELF : PersonBuilder<SELF>
    {
        protected Person person = new Person();

        public Person Build()
        {
            return person;
        }
    }

  public class PersonInfoBuilder<SELF> : PersonBuilder<PersonInfoBuilder<SELF>>
      where SELF : PersonInfoBuilder<SELF>
    {
        public SELF Called(string name)
        {
            person.Name = name;
            return (SELF)this;
        }
    }

  public  class PersonJobBuilder<SELF> : PersonInfoBuilder<PersonJobBuilder<SELF>>
      where SELF : PersonJobBuilder<SELF>
    {
        public SELF WorksAsA(string position)
        {
            person.Position = position;
            return (SELF)this;
        }
    }

    public class BuilderInheritanceDemo
    {
        static void Main(string[] args)
        {
            var test = Person.New
                     .Called("Matthew")
                     .WorksAsA("Software Developer");

            Console.WriteLine(test.ToString());

   
        }
    }
}