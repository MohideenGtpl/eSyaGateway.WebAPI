using eSyaGateway.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eSyaGateway.IF
{
    public interface IApplicationRulesRepository
    {
        Task<bool> GetApplicationRuleStatusByID(int processID, int ruleID);

        Task<List<DO_ApplicationRules>> GetApplicationRuleListByProcesssID(int processID);
    }
}
