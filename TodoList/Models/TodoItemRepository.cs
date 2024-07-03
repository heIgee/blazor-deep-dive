namespace TodoList.Models;

public static class TodoItemRepository
{
    private static readonly List<TodoItem> tasks =       
    [
        new("Survive"),
        new("Finish semester"),
        new("Get a job")
    ];

    public static List<TodoItem> FindAll() => [.. tasks.OrderBy(t => t.IsDone)];

    public static void AddNew() => tasks.Insert(0, new TodoItem("New task"));

    public static void Remove(TodoItem task) => tasks.Remove(task);
}
