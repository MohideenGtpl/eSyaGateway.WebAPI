using eSyaGateway.DO;
using eSyaGateway.IF;
using Microsoft.EntityFrameworkCore;
using HCP.Gateway.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSyaGateway.DL.Repository
{
    public class ApplicationRulesRepository : IApplicationRulesRepository
    {
        public async Task<bool> GetApplicationRuleStatusByID(int processID, int ruleID)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtEcprrl
                        .Join(db.GtEcaprl,
                            p => p.ProcessId,
                            r => r.ProcessId,
                            (p, r) => new { p, r })
                        .Where(w => w.p.ProcessId == processID && w.r.RuleId == ruleID
                            && w.p.ActiveStatus && w.r.ActiveStatus)
                       .CountAsync();

                    return await ds > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<List<DO_ApplicationRules>> GetApplicationRuleListByProcesssID(int processID)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtEcprrl
                        .Join(db.GtEcaprl,
                            p => p.ProcessId,
                            r => r.ProcessId,
                            (p, r) => new { p, r })
                        .Where(w => w.p.ProcessId == processID
                            && w.p.ActiveStatus)
                       .Select(s => new DO_ApplicationRules
                       {
                           ProcessID = s.p.ProcessId,
                           RuleID = s.r.RuleId,
                           RuleStatus = s.r.ActiveStatus
                       }).ToListAsync();

                    return await ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
