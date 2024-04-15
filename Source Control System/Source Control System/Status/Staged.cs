using Source_Control_System.Folder_Item;
using Source_Control_System.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceControlProject.Status;

public class Staged : IState
{
    private static Staged _instance;
    public static Staged GetInstance()
    {
        _instance ??= new Staged();
        return _instance;
    }
    public void ChangeStatus(Component component)
    {
        component.SetState(Commit.GetInstance());
    }
    private Staged()
    {
        
    }

    public string GetStatus()
    {
        return "staged";
    }
}
