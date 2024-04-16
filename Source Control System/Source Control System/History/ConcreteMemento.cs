using Source_Control_System.Folder_Item;
using Source_Control_System.Status;
using SourceControlProject.Status;

namespace SourceControlSystem.History;

public class ConcreteMemento : IMemento
{
    private readonly IState _state;

    private readonly DateTime _date;

    private readonly Dictionary<string, Component> _components = null;
    public ConcreteMemento(IState state, DateTime dateTime, Dictionary<string, Component> components)
    {
        _state = state;
        _date = dateTime;
        _components = components;
    }
    public ConcreteMemento(IState state, DateTime dateTime)
    {
        _state = state;
        _date = dateTime;
    }

    public Dictionary<string, Component> GetComponents()
    {
        return _components;
    }

    public DateTime GetDate()
    {
        return DateTime.Now;
    }

    public string GetName()
    {
        return $"{this._date} / {this._state}.";
    }

    public IState GetState()
    {
        return _state;
    }
}