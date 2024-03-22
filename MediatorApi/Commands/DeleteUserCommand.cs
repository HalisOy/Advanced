using MediatorApi.Context;
using MediatorApi.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediatorApi.Commands
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public int Id { get; private set; }
        public DeleteUserCommand(int id)
        {
            Id = id;
        }
        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
        {
            private MediatrDBContext _context;
            public DeleteUserCommandHandler(MediatrDBContext mediatrDBContext)
            {
                _context = mediatrDBContext;
            }
            public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                User deletedUser = await _context.Users.Where(user => user.Id == request.Id).FirstOrDefaultAsync();
                _context.Users.Remove(deletedUser);
                await _context.SaveChangesAsync();
                if (deletedUser == null)
                    return await Task.FromResult(false);
                return await Task.FromResult(true);
            }
        }
    }
}
