using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENothi_Desktop.ApiUtility;
using ENothi_Desktop.Dto.RequestDto;
using ENothi_Desktop.Interface.IManager;

namespace ENothi_Desktop.Manager
{
    public class DakActionManager : IDakActionManager
    {
        public bool DakArchive(DakActionArchiveDto request)
        {
            var response= DakActionApiHelper.DakArchive(request);
            return response;
        }
    }
}
