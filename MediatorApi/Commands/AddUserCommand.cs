using MediatorApi.Context;
using MediatorApi.DTOs;
using MediatorApi.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediatorApi.Commands;
public class AddUserCommand : IRequest<AddedUserDto>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, AddedUserDto>
    {
        //bağımlılıklar buraya tanımlanıyor
        public MediatrDBContext _context;
        public AddUserCommandHandler(MediatrDBContext context)
        {
            _context = context;
        }
        
        public async Task<AddedUserDto> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            //Add user operations
            AddedUserDto newuser = new AddedUserDto()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                Password = request.Password,
            };
            await _context.Users.AddAsync(new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                Password = request.Password,
            });
            await _context.SaveChangesAsync();
            return await Task.FromResult(newuser);
        }
    }
}
