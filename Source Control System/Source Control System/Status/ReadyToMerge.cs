using Source_Control_System.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Source_Control_System.Folder_Item;
using Source_Control_System.Status;
using SourceControlSystem.Status;

namespace SourceControlProject.Status;
public class ReadyToMerge : IState
{
    private static ReadyToMerge _instance;
    public static ReadyToMerge GetInstanse()
    {
        _instance ??= new ReadyToMerge();
        return _instance;
    }
    public void ChangeStatus(Component component)
    {
        component.SetState(Merged.GetInstance());
    }
    private ReadyToMerge()
    {

    }

    public string GetStatus()
    {
        return "ready to merge";
    }
}
