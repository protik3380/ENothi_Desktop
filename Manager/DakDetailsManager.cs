using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENothi_Desktop.ApiUtility;
using ENothi_Desktop.Dto.RequestDto;
using ENothi_Desktop.Interface.IManager;
using ENothi_Desktop.Models;

namespace ENothi_Desktop.Manager
{
    public class DakDetailsManager : IDakDetailsManager
    {
        public DakDetails GetDakDetails(DakDetailsDto request)
        {
            var response = DakDetailsApiHelper.GetDakDetailsByDakId(request);
            return response;
        }
    }
}
