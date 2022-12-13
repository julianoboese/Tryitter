using FluentAssertions;
using Tryitter.Api.Models;
using Tryitter.Api.Services;

namespace Tryitter.Test;

public class TokenGeneratorTest
{
    [Fact(DisplayName = "Teste para geração de Token.")]
    public void TestTokenGenerator()
    {
        var student = new Student()
        {
            StudentId = 1,
            Name = "Fulano Silva",
            Email = "fulano@email.com",
            Password = "password",
            ModuleId = 1,
        };

        var token = new TokenGenerator().Generate(student);

        token.Split('.').Should().NotBeNull();
        token.Split('.').Should().HaveCount(3);
    }
}