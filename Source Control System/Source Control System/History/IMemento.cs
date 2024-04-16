using Source_Control_System.Folder_Item;
using Source_Control_System.Status;
using SourceControlProject.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceControlSystem.History;

public interface IMemento
{
    string GetName();

    IState GetState();

    DateTime GetDate();
    Dictionary<string, Component> GetComponents();
}
