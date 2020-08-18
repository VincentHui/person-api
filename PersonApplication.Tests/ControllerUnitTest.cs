using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using testCRM.Controllers;
using testCRM.models;
using Xunit;

namespace PersonApplication.Tests {

    public class ControllerUnitTest {
        private readonly DbContextOptions<PersonContext> options;
        public ControllerUnitTest () {
            this.options = new DbContextOptionsBuilder<PersonContext> ()
                .UseInMemoryDatabase("TestDatabase")
                .Options;
        }

        [Fact]
        public async void GetPerson () {

            using (var context = new PersonContext (options)) {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var articles = new List<Person> {
                    new Person {Id = 5, Name = "testName", DateAdded = DateTime.MinValue },
                    new Person {Id = 10, Name = "testName2", DateAdded = DateTime.MaxValue },
                    new Person {Id = 6, Name = "testName3", DateAdded = DateTime.MinValue },
                    new Person {Id = 3, Name = "testName4", DateAdded = DateTime.MaxValue }
                };
                context.People.AddRange (articles);
                context.SaveChanges();

                PersonController pc = new PersonController(context);
                var people = await pc.GetPeople();
                Assert.Equal(people.Value, articles);
                var person = await pc.GetPerson(10);
                Assert.Equal("testName2", person.Value.Name);
                Assert.Equal(person.Value.DateAdded, DateTime.MaxValue);
            }
        }
        [Fact]
        public async void AddPerson () {

            using (var context = new PersonContext (options)) {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                PersonController pc = new PersonController(context);
                var personToAdd = new Person{Id=1, Name= "testPersonAdded", DateAdded= DateTime.MinValue};
                await pc.PostPerson(personToAdd);
                var people = await pc.GetPerson(1);
                Assert.Equal(people.Value.Name, personToAdd.Name);
                Assert.Equal(people.Value.Id, personToAdd.Id);
            }
        }

        [Fact]
        public async void DeletePerson () {

            using (var context = new PersonContext (options)) {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                var articles = new List<Person> {
                    new Person {Id = 5, Name = "toDelete", DateAdded = DateTime.MinValue },
                    new Person {Id = 10, Name = "testName2", DateAdded = DateTime.MaxValue }
                };
                context.People.AddRange (articles);
                context.SaveChanges();

                PersonController pc = new PersonController(context);
                await pc.DeletePerson(5);
                var people = await pc.GetPeople();
                var peopleArray = people.Value.ToArray();
                Assert.Single(peopleArray);
                Assert.Equal("testName2", peopleArray[0].Name);
                Assert.Equal(10, peopleArray[0].Id);
            }
        }
    }
}