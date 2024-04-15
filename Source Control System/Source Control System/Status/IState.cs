using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Source_Control_System.Folder_Item;
namespace Source_Control_System.Status;
public interface IState
{
    public void ChangeStatus(Component component);
    public string GetStatus();

}

