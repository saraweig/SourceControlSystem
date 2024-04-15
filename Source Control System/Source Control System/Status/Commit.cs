using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Source_Control_System.Folder_Item;
using Source_Control_System.Status;
using SourceControlProject.Status;

namespace Source_Control_System.Status;

public class Commit : IState
{
    private static Commit _instance;
    public static Commit GetInstance()
    {
        _instance ??= new Commit();
        return _instance;
    }
    public void ChangeStatus(Component component)
    {
        if (Admin.confirmReview(component))
        {
            component.SetState(UnderReview.GetInstance());
        }
    }
    private Commit()
    {
        
    }
    public string GetStatus()
    {
        return "Commit";
    }
}
