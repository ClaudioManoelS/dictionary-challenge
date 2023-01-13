using System.Security.Cryptography;
using System.Text;
using Dictionary.Infra.Interfaces;

namespace Dictionary.Infra.Services;

public class HashService : IHashService
{
  public string Generate(string text)
  {
    var md5 = MD5.Create();
    var bytes = Encoding.ASCII.GetBytes(text);
    var hash = md5.ComputeHash(bytes);

    var ret = new StringBuilder();
    foreach (var item in hash)
    {
      ret.Append(item.ToString("X2"));
    }
    return ret.ToString();
  }

  public bool Compare(string text, string hash)
  {
    return Generate(text).Trim() == hash.Trim();
  }
}