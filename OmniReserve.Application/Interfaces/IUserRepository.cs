using OmniReserve.Domain.Entities;
using OmniReserve.Domain.ValueObjects;
using MediatR;

namespace OmniReserve.Application.Interfaces;

public interface IUserRepository
{
    public Task AddAsync (User user);
    public Task<User?> GetByEmailAsync(EmailAddress email, CancellationToken cancellationToken);
}