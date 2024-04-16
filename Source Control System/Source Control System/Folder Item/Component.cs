using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Source_Control_System.Status;
using SourceControlSystem.History;
using SourceControlSystem.Status;

namespace Source_Control_System.Folder_Item;

public abstract class Component
{
    public IState State { get; private set; }
    public string Name { get; set; }

    public Component(string name)
    {
        this.Name = name;
        State = Draft.GetInstance();
    }
    public void SetState(IState state)
    {
        this.State = state;
    }
    public Component Add()
    {
        if (State.GetStatus() == "Draft")
        {
            State.ChangeStatus(this);
        }
        else
        {
            Console.WriteLine("cannot add - not draft");
        }
        return this;
    }
    public virtual Component Merge(Component other)
    {
        Console.WriteLine(other.State.GetStatus());
        if (other.State.GetStatus() != "ready to merge")
        {
            Console.WriteLine("This file can not be merged yet.");
            return this;
        }
        return other;
    }
    public virtual void Commit()
    {
        if (State.GetStatus() != "staged")
        {
            Console.WriteLine("This file can't be commited yet.");
        }
        else
        {
            State.ChangeStatus(this);
            State.ChangeStatus(this);
        }
    }
    public abstract IMemento Save();

    public void Restore(IMemento memento)
    {
        if (memento is not ConcreteMemento)
        {
            throw new Exception("Unknown memento class " + memento.ToString());
        }

        this.State = memento.GetState();
        Console.Write($"Originator: My state has changed to: {State.GetStatus()}");
    }

    public Component RequestAReview()
    {

        if (State.GetStatus() != "UnderReview")
        {
            Console.WriteLine("cant review yet");
        }
        else
        {
            State.ChangeStatus(this);
        }
        return this;
    }
    public abstract Component Copy();
}

