using Dictionary.Infra.Services;

namespace Dictionary.Tests.Domain.DictionaryContext.Entities;

[TestClass]
public class HashServiceTests
{
  [TestMethod]
  public void Hash_Password_And_Compare_With_Same_Password_Should_Be_Ok()
  {
    var hashService = new HashService();
    var password = "1234";
    var hash = hashService.Generate(password);

    Assert.IsTrue(hashService.Compare("1234", hash));
  }
}