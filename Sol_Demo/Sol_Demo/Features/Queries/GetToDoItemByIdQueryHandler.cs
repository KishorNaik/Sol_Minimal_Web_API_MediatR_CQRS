using MediatR;
using Sol_Demo.Data;
using Sol_Demo.Model;

namespace Sol_Demo.Features.Queries
{
    public record class GetToDoItemByIdQuery(int Id) : IRequest<ToDoModel>;

    public class GetToDoItemByIdQueryHandler : IRequestHandler<GetToDoItemByIdQuery, ToDoModel>
    {
        private readonly ToDoRepository? toDoRepository = null;

        public GetToDoItemByIdQueryHandler(ToDoRepository toDoRepository) => this.toDoRepository = toDoRepository;

        Task<ToDoModel> IRequestHandler<GetToDoItemByIdQuery, ToDoModel>.Handle(GetToDoItemByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var filterToDoModel = this?.toDoRepository?.ToDoList
                                    .FirstOrDefault((element) => element.Id == request.Id);
                return Task.FromResult(filterToDoModel!);
            }
            catch
            {
                throw;
            }
        }
    }
}