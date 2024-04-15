using Source_Control_System.Folder_Item;
using Source_Control_System.Status;
using SourceControlProject.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceControlSystem.Status;

public class Draft : IState
{
    private static Draft _instance;
    public static Draft GetInstance()
    {
        _instance ??= new Draft();
        return _instance;        
    }
    public void ChangeStatus(Component component)
    {
        component.SetState(Staged.GetInstance());
    }
    private Draft()
    {
        
    }
    public string GetStatus()
    {
        return "Draft";       
    }
}
