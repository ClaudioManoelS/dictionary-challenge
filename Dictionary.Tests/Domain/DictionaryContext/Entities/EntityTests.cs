using Dictionary.Domain.DictionaryContext.Entities;

namespace Dictionary.Tests.Domain.DictionaryContext.Entities;

[TestClass]
public class EntityTests
{
  [TestMethod]
  public void Should_Convert_Short_GUID_To_GUID_And_Get_Back_To_Short_GUID()
  {
    var obj = new Entity();
    var guid_original = obj.Id.ToString();
    var short_id_original = obj.ShortId;

    obj.Id = Guid.NewGuid();

    Assert.AreNotEqual(guid_original, obj.Id.ToString());
    Assert.AreNotEqual(short_id_original, obj.ShortId);

    obj.ShortId = short_id_original;

    Assert.AreEqual(guid_original, obj.Id.ToString());
    Assert.AreEqual(short_id_original, obj.ShortId);
  }
}