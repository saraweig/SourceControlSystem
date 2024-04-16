using Source_Control_System.Folder_Item;
using SourceControlSystem.History;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceControlSystem.FolderItem;

public class Folder : Component
{
    public Dictionary<string, Component> components = new Dictionary<string, Component>();

    public Folder(string name):base(name) 
    {
        components = new Dictionary<string, Component>();
    }

    public override Component Copy()
    {
        Folder folder = new(this.Name);
        folder.SetState(this.State);
        if (components != null)
        {
            foreach (Component item in this.components.Values)
            {
                item.Copy();
            }
        }
        return folder;
    }

    public override Component Merge(Component other)
    {
        Component folder = base.Merge(other);
        if (folder == other)
        {
            foreach (var component in ((Folder)other).components)
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

    public override IMemento Save()
    {
        return new ConcreteMemento(State, DateTime.Now, components);
    }
}
