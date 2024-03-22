using MediatorApi.Context;
using MediatorApi.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediatorApi.Queries;

public class UserListQuery : IRequest<IList<UserListDto>>
{
    public class UserListQueryHandler : IRequestHandler<UserListQuery, IList<UserListDto>>
    {
        public MediatrDBContext _context;
        public UserListQueryHandler(MediatrDBContext context)
        {
            _context = context;
        }
        public async Task<IList<UserListDto>> Handle(UserListQuery request, CancellationToken cancellationToken)
        {

            var users = await _context.Users.ToListAsync();
            return await Task.FromResult(users.Select(user => new UserListDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName
            }).ToList());
        }
    }
}
