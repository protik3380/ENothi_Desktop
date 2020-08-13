using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENothi_Desktop.Dto.RequestDto;
using ENothi_Desktop.Models;

namespace ENothi_Desktop.Interface.IManager
{
    public  interface IDakInboxManager
    {
        ModulePendingCount GetPendingModuleCount(ModuleCountDto moduleCountRequest, string token);
    }
}
