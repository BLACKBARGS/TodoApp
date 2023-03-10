using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands;

public class CreateTodoCommand : Notifiable<Notification>, ICommand
{
    public CreateTodoCommand() {}

    public CreateTodoCommand(string? title, string? user, DateTime date)
    {
        Title = title;
        User = user;
        Date = date;
    }

    public string? Title {get; set;}
    public string? User {get; set;}
    public DateTime Date {get; set;}

    public void Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsLowerThan(Title, 5, "Title", "Invalid Title")
                    .IsLowerThan(User, 5, "User", "User Invalid!")
            );
        }

    bool ICommand.Validate() => throw new NotImplementedException();
}