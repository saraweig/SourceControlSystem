using Source_Control_System.Folder_Item;
using SourceControlSystem.History;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceControlSystem.FolderItem;

public class MyFile : Component
{
    public string Content;
    public MyFile(string name, string content) : base(name)
    {
        this.Content = content;
    }

    public override Component Copy()
    {
        MyFile file = (MyFile)this.MemberwiseClone();
        file.SetState(this.State); 
        return file;
    }

    public override Component Merge(Component other)
    {
        Component myFile = base.Merge(other);
        if (myFile == other)
        {
            if (((MyFile)myFile).Content.Equals(((MyFile)other).Content))
            {
                Console.WriteLine("The files are same");
            }
            else
            {
                Console.WriteLine("The files were merged successfully😊.");
            }
        }
        return myFile;

    }

    public override IMemento Save()
    {
        return new ConcreteMemento(State, DateTime.Now);
    }
}
