using FluentAssertions;
using System.Threading.Channels;
using Tryitter.Api.DTOs;
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
                new()
                {
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

        [Theory]
        [MemberData(nameof(TestGetStudentByIdData))]
        public void TestGetStudentById(TryitterContext context, int id, Student expectedStudent)
        {
            // Arrange
            var repository = new StudentRepository(context);

            // Act
            var student = repository.GetStudentById(id);

            // Assert
            student.Should().BeEquivalentTo(expectedStudent);
        }

        public readonly static TheoryData<TryitterContext, int, Student> TestGetStudentByIdData = new()
        {
            {
                Helpers.GetContextInstanceForTests("TestGetStudentById"),
                2,
                new Student
                {
                    StudentId = 2,
                    Name = "Beltrano Souza",
                    Email = "beltrano@email.com",
                    Password = "123456",
                    ModuleId = 3,
                    Module = new Module { ModuleId = 3, Name = "Back-end" },
                }
            }
        };

        [Theory]
        [MemberData(nameof(TestGetStudentByEmailAndPasswordData))]
        public void TestGetStudentByEmailAndPassword(TryitterContext context, AuthInput authInput, Student expectedStudent)
        {
            // Arrange
            var repository = new StudentRepository(context);

            // Act
            var student = repository.GetStudentByEmailAndPassword(authInput);

            // Assert
            student.Should().BeEquivalentTo(expectedStudent);
        }

        public readonly static TheoryData<TryitterContext, AuthInput, Student> TestGetStudentByEmailAndPasswordData = new()
        {
            {
                Helpers.GetContextInstanceForTests("TestGetStudentByEmailAndPassword"),
                new AuthInput
                {
                    Email = "ciclano@email.com",
                    Password = "12345678",
                },
                new Student
                {
                    StudentId = 3,
                    Name = "Ciclano Cardoso",
                    Email = "ciclano@email.com",
                    Password = "12345678",
                    ModuleId = 4,
                    Module = new Module { ModuleId = 4, Name = "Ciência da Computação" },
                }
            }
        };

        [Theory]
        [MemberData(nameof(TestGetStudentsByNameData))]
        public void TestGetStudentsByName(TryitterContext context, string name, List<Student> expectedStudents)
        {
            // Arrange
            var repository = new StudentRepository(context);

            // Act
            var student = repository.GetStudentsByName(name);

            // Assert
            student.Should().BeEquivalentTo(expectedStudents);
        }

        public readonly static TheoryData<TryitterContext, string, List<Student>> TestGetStudentsByNameData = new()
        {
            {
                Helpers.GetContextInstanceForTests("TestGetStudentsByName"),
                "Fulano",
                new()
                {
                    new Student
                    {
                        StudentId = 1,
                        Name = "Fulano Silva",
                        Email = "fulano@email.com",
                        Password = "password",
                        ModuleId = 1,
                        Module = new Module { ModuleId = 1, Name = "Fundamentos" },
                    },
                }
            }
        };

        [Theory]
        [MemberData(nameof(TestAddStudentData))]
        public void TestAddStudent(TryitterContext context, Student student, List<Student> expectedStudents)
        {
            // Arrange
            var repository = new StudentRepository(context);

            // Act
            repository.AddStudent(student);
            var students = repository.GetStudents();

            // Assert
            students.Should().BeEquivalentTo(expectedStudents);
        }

        public readonly static TheoryData<TryitterContext, Student, List<Student>> TestAddStudentData = new()
        {
            {
                Helpers.GetContextInstanceForTests("TestAddStudent"),
                new Student
                    {
                        Name = "José Gonçalves",
                        Email = "jose@email.com",
                        Password = "senha",
                        ModuleId = 2,
                    },
                new()
                {
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
                    new Student
                    {
                        StudentId = 4,
                        Name = "José Gonçalves",
                        Email = "jose@email.com",
                        Password = "senha",
                        ModuleId = 2,
                        Module = new Module { ModuleId = 2, Name = "Front-end" },
                    },
                }
            }
        };

        [Theory]
        [MemberData(nameof(TestUpdateStudentData))]
        public void TestUpdateStudent(TryitterContext context, int id, Student studentChanges, List<Student> expectedStudents)
        {
            // Arrange
            var repository = new StudentRepository(context);

            var student = repository.GetStudentById(id);
            student.Email = studentChanges.Email;
            student.Password = studentChanges.Password;
            student.ModuleId = studentChanges.ModuleId;

            // Act
            repository.UpdateStudent(student);
            var students = repository.GetStudents();

            // Assert
            students.Should().BeEquivalentTo(expectedStudents);
        }

        public readonly static TheoryData<TryitterContext, int, Student, List<Student>> TestUpdateStudentData = new()
        {
            {
                Helpers.GetContextInstanceForTests("TestUpdateStudent"),
                2,
                new Student
                {
                    Email = "beltrano@outroemail.com",
                    Password = "outrasenha",
                    ModuleId = 4,
                },
                new()
                {
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
                        Email = "beltrano@outroemail.com",
                        Password = "outrasenha",
                        ModuleId = 4,
                        Module = new Module { ModuleId = 4, Name = "Ciência da Computação" },
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

        [Theory]
        [MemberData(nameof(TestDeleteStudentData))]
        public void TestDeleteStudent(TryitterContext context, int id, List<Student> expectedStudents)
        {
            // Arrange
            var repository = new StudentRepository(context);

            var student = repository.GetStudentById(id);

            // Act
            repository.DeleteStudent(student);
            var students = repository.GetStudents();

            // Assert
            students.Should().BeEquivalentTo(expectedStudents);
        }

        public readonly static TheoryData<TryitterContext, int, List<Student>> TestDeleteStudentData = new()
        {
            {
                Helpers.GetContextInstanceForTests("TestDeleteStudent"),
                1,
                new()
                {
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
