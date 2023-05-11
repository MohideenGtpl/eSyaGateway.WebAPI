using HCP.Gateway.DL.Entities;
using HCP.Gateway.DO;
using HCP.Gateway.IF;
using Microsoft.EntityFrameworkCore;
using NG.Gateway.DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCP.Gateway.DL.Repository
{
   public  class SmsReminderRepository : ISmsReminderRepository
    {
        public async Task<List<DO_SmsReminder>> GetSmsReminderSchedule()
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtEcsmss
                     .Where(w => w.ActiveStatus)
                     .Select(r => new DO_SmsReminder
                     {
                         ReminderType = r.ReminderType,
                         SmsId = r.Smsid,
                         ScheduleOnDay = r.ScheduleOnDay,
                         ScheduleTime = r.ScheduleTime
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
