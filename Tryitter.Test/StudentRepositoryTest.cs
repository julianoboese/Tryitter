using FluentAssertions;
using System.Threading.Channels;
using Tryitter.Api.Models;
using Tryitter.Api.Repository;

namespace Tryitter.Test
{
    public class StudentRepositoryTest
    {
        [Theory]
        [MemberData(nameof(TestGetStudentsData))]
        public void TestGetStudents(TryitterContext context, List<Student> expectedStudents)
        {
            // Arrange
            var repository = new StudentRepository(context);

            // Act
            var students = repository.GetStudents();

            // Assert
            students.Should().BeEquivalentTo(expectedStudents);
        }

        public readonly static TheoryData<TryitterContext, List<Student>> TestGetStudentsData = new()
        {
            {
                Helpers.GetContextInstanceForTests("TestGetStudents"),
                new() {
                    new Student
                    {
                        StudentId = 1,
                        Name = "Fulano Silva",
                        Email = "fulano@email.com",
                        Password = "password",
                        ModuleId = 1,
                        Module = new Module { ModuleId = 1, Name = "Fundamentos" },
                    },
                    new Student
                    {
                        StudentId = 2,
                        Name = "Beltrano Souza",
                        Email = "beltrano@email.com",
                        Password = "123456",
                        ModuleId = 3,
                        Module = new Module { ModuleId = 3, Name = "Back-end" },
                    },
                    new Student
                    {
                        StudentId = 3,
                        Name = "Ciclano Cardoso",
                        Email = "ciclano@email.com",
                        Password = "12345678",
                        ModuleId = 4,
                        Module = new Module { ModuleId = 4, Name = "Ciência da Computação" },
                    },
                }
            }
        };
    }
}
