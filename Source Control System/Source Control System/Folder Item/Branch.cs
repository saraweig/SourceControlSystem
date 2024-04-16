using Source_Control_System.Folder_Item;
using SourceControlSystem.History;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceControlSystem.FolderItem;

public class Branch:Component
{
    public Dictionary<string, Component> components = new Dictionary<string, Component>();

    public Branch(string name):base(name)
    {
        
    }
    public void Add(Component component)
    {
        components.Add(component.Name, component);
    }
    public override Component Merge(Component other)
    {
        Component branch = base.Merge(other);
        if (branch == other)
        {
            foreach (var component in ((Branch)other).components)
            {
                if (components.ContainsKey(component.Key))
                {
                    this.components[component.Key].Merge(component.Value);
                }
                else
                {
                    components.Add(component.Key, component.Value);
                }
            }
        }
        return this;
    }
    public override Component Copy()
    {
        Branch branch = new(this.Name);
        branch.SetState(State);
        if (components == null)
        {
            return branch;
        }
        foreach (Component item in this.components.Values)
        {
            item.Copy();
        }
        return branch;
    }

    public override IMemento Save()
    {
        return new ConcreteMemento(State, DateTime.Now, components);
    }
}
