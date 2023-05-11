﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eSyaGateway.DO;
using eSyaGateway.IF;
using eSyaGateway.WebAPI.Services;
using HCP.Gateway.DO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eSyaGateway.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SmsSenderController : ControllerBase
    {
        private readonly ISmsStatementRepository _smsStatementRepository;
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly ISmsSender _smsSender;

        public SmsSenderController(ISmsStatementRepository smsStatementRepository, IUserAccountRepository userAccountRepository, ISmsSender smsSender)
        {
            _smsStatementRepository = smsStatementRepository;
            _userAccountRepository = userAccountRepository;
            _smsSender = smsSender;
        }

        [HttpPost]
        public async Task<IActionResult> SendSmsForForm(DO_SmsParameter sp_obj)
        {
            var fs = await _smsStatementRepository.GetSmsStatementByForm(sp_obj);

            if(sp_obj.IsUserPasswordInclude)
            {
                sp_obj.Password = await _userAccountRepository.GetUserPassword(sp_obj.UserID);

            }

            string mobileNumber = "", messageText = "";
            foreach (var s in fs)
            {
                foreach(var r in s.l_SmsParam.Where(w => w.MobileNumber != null))
                {
                    if (r.ParameterID == (int)smsParams.User)
                    {
                        sp_obj.LoginID = r.ID;
                        sp_obj.UserName = r.Name;
                    }
                }
                messageText = TextualMessageReplaceByVariables(s.SMSStatement, sp_obj);
                foreach (var p in s.l_SmsParam.Where(w => w.MobileNumber != null))
                {
                    if (!string.IsNullOrEmpty(p.MobileNumber))
                    {
                      var rp =  await _smsSender.SendAsync(p.MobileNumber, messageText);
                      await  _smsStatementRepository.Insert_SmsLog(new NG.Gateway.DO.DO_SMSLog
                        {
                            MessageType = sp_obj.MessageType,
                            MobileNumber = p.MobileNumber,
                            SMSStatement = messageText,
                            RequestMessage = rp.RequestMessage,
                            ResponseMessage = rp.ResponseMessage,
                            SendStatus = rp.SendStatus,
                        });
                    }
                }
                if(s.l_SmsRecipient.Count() > 0)
                    mobileNumber = string.Join(",", s.l_SmsRecipient.Select(w => w.MobileNumber));

                if (!string.IsNullOrEmpty(mobileNumber))
                {
                    var rp = await _smsSender.SendAsync(mobileNumber, messageText);
                   await _smsStatementRepository.Insert_SmsLog(new NG.Gateway.DO.DO_SMSLog
                    {
                        MessageType = sp_obj.MessageType,
                        MobileNumber = mobileNumber,
                        SMSStatement = messageText,
                        RequestMessage = rp.RequestMessage,
                        ResponseMessage = rp.ResponseMessage,
                        SendStatus = rp.SendStatus,
                    });
                }
            }
            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> SendSmsForId(DO_SmsParameter sp_obj)
        {
            var fs = await _smsStatementRepository.GetSmsStatementById(sp_obj);

            if (sp_obj.IsUserPasswordInclude)
            {
                sp_obj.Password = await _userAccountRepository.GetUserPassword(sp_obj.UserID);

            }

            string mobileNumber = "", messageText = "";
            foreach (var s in fs)
            {
                foreach (var r in s.l_SmsParam.Where(w => w.MobileNumber != null))
                {
                    if (r.ParameterID == (int)smsParams.User)
                    {
                        sp_obj.LoginID = r.ID;
                        sp_obj.UserName = r.Name;
                    }
                }
                messageText = TextualMessageReplaceByVariables(s.SMSStatement, sp_obj);
                foreach (var p in s.l_SmsParam.Where(w => w.MobileNumber != null))
                {
                    if (!string.IsNullOrEmpty(p.MobileNumber))
                    {
                        var rp = await _smsSender.SendAsync(p.MobileNumber, messageText);
                        await _smsStatementRepository.Insert_SmsLog(new NG.Gateway.DO.DO_SMSLog
                        {
                            MessageType = sp_obj.MessageType,
                            MobileNumber = p.MobileNumber,
                            SMSStatement = messageText,
                            RequestMessage = rp.RequestMessage,
                            ResponseMessage = rp.ResponseMessage,
                            SendStatus = rp.SendStatus,
                        });

                        await _smsStatementRepository.Insert_SmsReminderLog(new DO_SmsReminder
                        {
                            ReminderType = sp_obj.ReminderType,
                            SmsId = sp_obj.SMSID,
                            ReferenceKey = sp_obj.ReferenceKey,
                            SendStatus = rp.SendStatus,
                        });
                    }
                }
                if (s.l_SmsRecipient.Count() > 0)
                    mobileNumber = string.Join(",", s.l_SmsRecipient.Select(w => w.MobileNumber));

                if (!string.IsNullOrEmpty(mobileNumber))
                {
                    var rp = await _smsSender.SendAsync(mobileNumber, messageText);
                    await _smsStatementRepository.Insert_SmsLog(new NG.Gateway.DO.DO_SMSLog
                    {
                        MessageType = sp_obj.MessageType,
                        MobileNumber = mobileNumber,
                        SMSStatement = messageText,
                        RequestMessage = rp.RequestMessage,
                        ResponseMessage = rp.ResponseMessage,
                        SendStatus = rp.SendStatus,
                    });
                }
            }
            return Ok();
        }


        public string TextualMessageReplaceByVariables(string smsTemplate, DO_SmsParameter sv)
        {
            //foreach (var sv in smsVariables)
            //{
            //    smsTemplate = smsTemplate.Replace(sv.Key, sv.Value);
            //}
            if(!string.IsNullOrEmpty(sv.OTP))
                smsTemplate = smsTemplate.Replace("V0001", sv.OTP);
            if (!string.IsNullOrEmpty(sv.LoginID))
                smsTemplate = smsTemplate.Replace("V0002", sv.LoginID);
            if (!string.IsNullOrEmpty(sv.UserName))
                smsTemplate = smsTemplate.Replace("V0003", sv.UserName);
            if (!string.IsNullOrEmpty(sv.Password))
                smsTemplate = smsTemplate.Replace("V0004", sv.Password);
            if (!string.IsNullOrEmpty(sv.Name))
                smsTemplate = smsTemplate.Replace("V0006", sv.Name);
            if (sv.ScheduleDate != null)
                smsTemplate = smsTemplate.Replace("V0007", sv.ScheduleDate.Value.ToString("dd-MMM-yyyy"));

            return smsTemplate;
        }
    }

    
}