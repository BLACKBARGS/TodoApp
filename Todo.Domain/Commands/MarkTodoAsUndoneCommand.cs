using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands;

public class MarkTodoAsUndoneCommand : Notifiable<Notification>, ICommand
{
    public MarkTodoAsUndoneCommand() {}

    public MarkTodoAsUndoneCommand(Guid id, string user)
    {
        Id = id;
        User = user;
    }

    public Guid Id {get; set;}
    public string? User {get; set;}

    public void Validate()
    {
        AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsLowerThan(User, 5, "User", "Invalid User!")
        );
    }

    bool ICommand.Validate() => throw new NotImplementedException();
}
