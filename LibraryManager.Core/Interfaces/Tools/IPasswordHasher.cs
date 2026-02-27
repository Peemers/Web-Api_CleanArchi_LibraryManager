namespace LibraryManager.Core.Interfaces.Tools;

public interface IPasswordHasher
{
  string hash(string password);
  bool verify(string password, string passwordHash);
}