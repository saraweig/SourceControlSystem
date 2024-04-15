using Source_Control_System.Folder_Item;
using Source_Control_System.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceControlSystem.Status;
public class Merged : IState
{
    private static Merged _instance;
    public static Merged GetInstance()
    {
        _instance ??= new Merged();
        return _instance;
    }
    public void ChangeStatus(Component component)
    {
        Console.WriteLine("marge completed");
    }
    private Merged()
    {

    }
    public string GetStatus()
    {
        return "merged";
    }
}
