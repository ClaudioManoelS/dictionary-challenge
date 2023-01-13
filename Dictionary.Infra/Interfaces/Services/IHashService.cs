namespace Dictionary.Infra.Interfaces;

public interface IHashService
{
  bool Compare(string text, string hash);
  string Generate(string text);
}
