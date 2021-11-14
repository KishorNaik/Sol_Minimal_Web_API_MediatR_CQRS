using MediatR;
using Sol_Demo.Data;
using Sol_Demo.Model;

namespace Sol_Demo.Features.Queries
{
    public class GetAllToDoListQuery : IRequest<List<ToDoModel>>
    {
    }

    public class GetAllToDoListQueryHandler : IRequestHandler<GetAllToDoListQuery, List<ToDoModel>>
    {
        private readonly ToDoRepository? toDoRepository = null;

        public GetAllToDoListQueryHandler(ToDoRepository toDoRepository) => this.toDoRepository = toDoRepository;

        Task<List<ToDoModel>> IRequestHandler<GetAllToDoListQuery, List<ToDoModel>>.Handle(GetAllToDoListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return Task.FromResult<List<ToDoModel>>(result: this?.toDoRepository?.ToDoList!);
            }
            catch
            {
                throw;
            }
        }
    }
}