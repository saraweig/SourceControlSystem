using Source_Control_System.Folder_Item;
using Source_Control_System.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceControlProject.Status;

public class UnderReview : IState
{
    private static UnderReview _instance;
    public static UnderReview GetInstance()
    {
        _instance ??= new UnderReview();
        return _instance;
    }
    public void ChangeStatus(Component component)
    {

        component.SetState(ReadyToMerge.GetInstance());
    }
    private UnderReview()
    {
           
    }
    public string GetStatus()
    {
        return "UnderReview";
    }
}
