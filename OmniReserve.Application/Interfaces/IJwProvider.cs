using OmniReserve.Domain.Entities;

namespace OmniReserve.Application.Interfaces;

public interface IJwProvider
{
public string Generate(User user);

}