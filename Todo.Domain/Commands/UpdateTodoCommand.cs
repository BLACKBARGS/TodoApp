using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands;

public class UpdateTodoCommand : Notifiable<Notification>, ICommand
{
    public UpdateTodoCommand() { }

    public UpdateTodoCommand(Guid id, string title, string user)
    {
        Id = id;
        Title = title;
        User = user;
    }

    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? User { get; set; }

    public void Validate()
    {
        AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsLowerThan(Title, 5, "Title", "Invalid Title")
                .IsLowerThan(User, 5, "User", "User Invalid!")
        );
    }

    bool ICommand.Validate()
    {
        throw new NotImplementedException();
    }
}