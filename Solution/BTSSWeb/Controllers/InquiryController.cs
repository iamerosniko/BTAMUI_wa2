using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BTSSWeb.Models;
using System.Web.Http.Cors;

namespace BTSSWeb.Controllers
{  
    [EnableCors(origins: "http://google.com.ph", headers: "*", methods: "*")]
    public class InquiryController : ApiController
    {
        private BTSSWebContext db = new BTSSWebContext();
        
        [Route("4399a480-e29b-4f6e-9408-962bad10991e/Inquiry")]
        public InquiryResult PostInquiry(Inquiry inquiry)
        {
            InquiryResult ir = new InquiryResult();
            int appID=GetApplicationID(inquiry.ApplicationName);
            int userID=GetUserID(inquiry.UserName);
            int tableID=GetTableID(inquiry.TableName);
            List<ApplicationGroups> appGroups;

            if (inquiry.TableName.Equals("_role_") && inquiry.Action.Equals("_role_"))
            {
                tableID = -1;
            }

            if (appID > 0 && userID > 0 && (tableID > 0||tableID==-1))
            {
                //2phase checking
                appGroups = db.ApplicationGroups.Where(x => x.ApplicationID == appID).ToList();
                if (appGroups.Count() > 0)
                {
                    //third phase checking
                    foreach (ApplicationGroups ag in appGroups)
                    {
                        ir = CheckRole(inquiry.Action, ag.applicationGroupID, tableID, userID);
                        if (ir.Result)
                        {
                            //insert adding to log
                            Audit audit = new Audit
                            {
                                Action = inquiry.Action,
                                Application = inquiry.ApplicationName,
                                AuditID = Guid.NewGuid(),
                                DateCreated = DateTime.Now,
                                Table = inquiry.TableName,
                                User = inquiry.UserName
                            };

                            try
                            {
                                db.Audit.Add(audit);
                                db.SaveChanges();
                            }
                            catch { }

                            return ir;
                        }
                    }
                }
            }
            return ir;
        }

        private int GetApplicationID(string applicationName)
        {
            List<Applications> apps = db.Applications.Where(a => a.ApplicationName.Equals(applicationName) && a.IsActive == true).ToList();
            return (apps.Count() != 0) ? apps.First().ApplicationID : 0;
        }

        private int GetTableID(string tableName)
        {
            List<Tables> tables = db.Tables.Where(a => a.TableName.Equals(tableName) && a.IsActive==true).ToList();
            return (tables.Count() != 0) ? tables.First().TableID : 0;
        }

        private int GetUserID(string username) 
        {
            List<Users> users = db.Users.Where(a => a.UserName.Equals(username) && a.IsActive == true).ToList();
            return (users.Count() != 0) ? users.First().UserID : 0;
        }

        private InquiryResult CheckRole(string action, System.Guid appGroupID, int tableID, int userID)
        {
            InquiryResult ir = new InquiryResult();
            List<ApplicationGroupTables> appGrpTables =
                db.ApplicationGroupTables.Where(x => x.ApplicationGroupID == appGroupID
                    && x.TableID == tableID).ToList();

            List<ApplicationGroupUsers> appGrpUsers =
                db.ApplicationGroupUsers.Where(x => x.ApplicationGroupID == appGroupID
                    && x.UserID == userID).ToList();

            if (appGrpTables.Count() >0 &&
                appGrpUsers.Count() >0 && 
                checkAction(appGrpTables.First(), action))
            {
                ir.Result = true;
            }

            else if(appGrpUsers.Count() > 0 && action == "_role_" && tableID==-1)
            {
                List<ApplicationGroupModules> appGrpModules =
                db.ApplicationGroupModules.Where(x => x.ApplicationGroupID == appGroupID).ToList();

                List<Modules> modules = getModules(appGrpModules);
                ir.Result = true;
                ir.Modules = modules;
            }

            return ir;
        }

        private bool checkAction(ApplicationGroupTables appGrpTable,string action)
        {
            switch (action.ToLower())
            {
                case "get":
                    return appGrpTable.CanGet;
                case "post":
                    return appGrpTable.CanPost;
                case "put":
                    return appGrpTable.CanPut;
                case "delete":
                    return appGrpTable.CanDelete;
                default:
                    return false;
            }
        }

        private List<Modules> getModules(List<ApplicationGroupModules> appGroupModules)
        {
            List<Modules> modules = new List<Modules>();
            foreach (ApplicationGroupModules agm in appGroupModules)
            {
                Modules module = db.Modules.Find(agm.ModuleID);
                if (modules != null)
                {
                    modules.Add(module);
                }
            }
            return modules;
        }
            
    }
}
