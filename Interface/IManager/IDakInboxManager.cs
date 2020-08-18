using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENothi_Desktop.Dto.RequestDto;
using ENothi_Desktop.Models;
using ENothi_Desktop.Models.DakInbox;

namespace ENothi_Desktop.Interface.IManager
{
    public  interface IDakInboxManager
    {
        ModulePendingCount GetPendingModuleCount(ModuleCountDto moduleCountRequest);
        DakInbox GetDakInboxListData(DakInboxDto request);
        MovementStatusVm GetDakMovementStatusByDakId(DakMovementDto request);
        DakInbox GetArchiveDakListData(DakInboxDto request);
    }
}
