namespace TodoList.Models;

public class TodoItem 
{
    public Guid Id { get; } = Guid.NewGuid();

    public TodoItem(string name)
    {
        this.name = name;
    }

    public string name;

    private bool _isDone;
    public bool IsDone
    {
        get => _isDone;
        set 
        {
            _isDone = value;
            if (_isDone)
            {
                DateCompleted = DateOnly.FromDateTime(DateTime.Now);
            }

        }
    }

    public DateOnly DateCompleted { get; private set; }
}
