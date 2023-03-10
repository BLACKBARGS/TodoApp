using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.EntityTests;

[TestClass]
public class TodoQueryTests
{
    private List<TodoItem> _items;

    public TodoQueryTests()
    {
        _items = new List<TodoItem>();
        _items.Add(new TodoItem("Tarefa 1", "usuarioA", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 2", "usuarioA", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 3", "blackbargsgo", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 4", "usuarioA", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 5", "blackbargsgo", DateTime.Now));
    }

    [TestMethod]
    public void Dada_a_consulta_deve_retornar_tarefas_apenas_do_usuario_blackbargsgo()
    {
        var result = _items.AsQueryable().Where(TodoQueries.GetAll("blackbargsgo"));
        Assert.AreEqual(2, result.Count());
    }
}