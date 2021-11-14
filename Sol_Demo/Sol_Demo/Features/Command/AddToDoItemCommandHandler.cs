using MediatR;
using Sol_Demo.Data;
using Sol_Demo.Model;

namespace Sol_Demo.Features.Command
{
    public record class AddToDoItemCommand(int Id, string Task) : IRequest<bool>;

    public class AddToDoItemCommandHandler : IRequestHandler<AddToDoItemCommand, bool>
    {
        private readonly ToDoRepository? toDoRepository = null;

        public AddToDoItemCommandHandler(ToDoRepository toDoRepository) => this.toDoRepository = toDoRepository;

        Task<bool> IRequestHandler<AddToDoItemCommand, bool>.Handle(AddToDoItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                this?.toDoRepository?.ToDoList.Add(new ToDoModel(request.Id, request.Task, false));
                return Task.FromResult<bool>(true);
            }
            catch
            {
                throw;
            }
        }
    }
}