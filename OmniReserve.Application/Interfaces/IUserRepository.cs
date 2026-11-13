using OmniReserve.Domain.Entities;
using MediatR;

namespace OmniReserve.Application.Interfaces;

public interface IUserRepository
{
    public Task AddAsync (User user);
}