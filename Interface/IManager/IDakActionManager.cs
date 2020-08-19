using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENothi_Desktop.Dto.RequestDto;

namespace ENothi_Desktop.Interface.IManager
{
     public interface IDakActionManager
     {
         bool DakArchive(DakActionArchiveDto request);
     }
}
