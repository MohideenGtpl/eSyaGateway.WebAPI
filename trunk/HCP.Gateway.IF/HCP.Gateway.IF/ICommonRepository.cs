using eSyaGateway.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eSyaGateway.IF
{
    public interface ICommonRepository
    {
        Task<List<DO_ISDCodes>> GetISDCodes();

        Task<List<DO_ApplicationCodes>> GetApplicationCodesByCodeType(int codeType);
    }
}
