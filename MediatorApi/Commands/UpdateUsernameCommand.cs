using MediatR;

namespace MediatorApi.Commands;

public class UpdateUsernameCommand:IRequest<bool>
{
    public int Id { get; set; }
    public string Username { get; set; }

    public class UpdateUsernameCommandHandler : IRequestHandler<UpdateUsernameCommand, bool>
    {
        public async Task<bool> Handle(UpdateUsernameCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(true);
        }
    }
}
