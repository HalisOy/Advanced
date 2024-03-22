using MediatorApi.Context;
using MediatorApi.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediatorApi.Queries;

public class UserGetByIdQuery(int id) : IRequest<UserGetByIdDto>
{
    public int Id {get; private set; } = id;

    public class UserGetByIdQueryHandler : IRequestHandler<UserGetByIdQuery, UserGetByIdDto>
    {
        public MediatrDBContext _context;
        public UserGetByIdQueryHandler(MediatrDBContext context)
        {
            _context = context;
        }
        public async Task<UserGetByIdDto> Handle(UserGetByIdQuery request, CancellationToken cancellationToken)
        {

            var user = await _context.Users.Where(user=> user.Id == request.Id).FirstOrDefaultAsync();
            return await Task.FromResult(new UserGetByIdDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName

            });
        }
    }
}
