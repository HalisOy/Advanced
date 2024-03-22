using MediatorApi.DTOs;
using MediatR;

namespace MediatorApi.Commands;

public class UpdateUserCommand : IRequest<UpdatedUserDto>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public class AddUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdatedUserDto>
    {
        //bağımlılıklar buraya tanımlanıyor
        public async Task<UpdatedUserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            //Add user operations
            return await Task.FromResult(new UpdatedUserDto()
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName
            });
        }
    }
}