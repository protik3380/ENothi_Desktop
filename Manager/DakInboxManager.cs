using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENothi_Desktop.ApiUtility;
using ENothi_Desktop.Dto.RequestDto;
using ENothi_Desktop.Interface.IManager;
using ENothi_Desktop.Models;
using ENothi_Desktop.Models.DakInbox;

namespace ENothi_Desktop.Manager
{
   public class DakInboxManager : IDakInboxManager
    {
        public ModulePendingCount GetPendingModuleCount(ModuleCountDto moduleCountRequest, string token)
        {          
            var response = DakInboxApiHelper.GetModulePendingCount(token,moduleCountRequest);
            return response;
        }

        public DakInbox GetDakInboxListData(DakInboxDto request)
        {
            var response = DakInboxApiHelper.GetDakInboxData(request);
            return response;
        }
    }
}
