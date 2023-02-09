using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers;

public class TodoHandler : Notifiable<Notification>, IHandler<CreateTodoCommand>
{
    private readonly ITodoRepository _repository;

    public TodoHandler(ITodoRepository repository) => _repository = repository; 
    
    public ICommandResult Handle(CreateTodoCommand command) 
    { 
        command.Validate(); 

        AddNotifications(command);

        if (command.IsValid == false) 
            return new GenericCommandResult(false,"Ops, looks like your task is invalid", command);

        var todo = new TodoItem(command.Title, command.User, command.Date);
        
        _repository.Create(todo);

        return new GenericCommandResult(true, "Task save with success", todo);
    
    }
}