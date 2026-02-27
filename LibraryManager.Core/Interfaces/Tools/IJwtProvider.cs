using LibraryManager.Domain.Entities;

namespace LibraryManager.Core.Interfaces.Tools;

public interface IJwtProvider
{
  string Generate(User user);
}