using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests;

[TestClass]
public class CreateTodoCommandTests
{
    private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);
    private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Task Title", "blackbargsgo", DateTime.Now);

    public CreateTodoCommandTests()
    {
        _invalidCommand.Validate();
        _validCommand.Validate();
    }

    [TestMethod]
    public void Dado_um_comando_invalido() => Assert.AreEqual(_invalidCommand.IsValid, false);
    
    [TestMethod]
    public void Dado_um_comando_valido() => Assert.AreEqual(_validCommand.IsValid, true);
}