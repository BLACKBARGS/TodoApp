using Flunt.Validations;
using Flunt.Notifications;

namespace Todo.Domain.Commands.Contracts;

public interface ICommand : IValidatable<Notification>
{
    bool Validate();
    

}
public interface IValidatable<T>
{
}