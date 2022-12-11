using FluentAssertions;
using Tryitter.Api.Services;

namespace Tryitter.Test;

public class TokenGeneratorTest
{
    [Fact(DisplayName = "Teste para geração de Token.")]
    public void TestTokenGenerator()
    {
        var token = new TokenGenerator().Generate();

        token.Split('.').Should().NotBeNull();
        token.Split('.').Should().HaveCount(3);
    }
}