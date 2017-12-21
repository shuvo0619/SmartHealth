using Microsoft.AspNet.SignalR;
using SmartHealth.Data;
using SmartHealth.Hubs;
using SmartHealth.Model.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SmartHealth
{
    public class NotificationComponent
    {
        public void RegisterNotification(DateTime currentTime)
        {
            string ConStr = ConfigurationManager.ConnectionStrings["SmartHealth_Entities"].ConnectionString;
            string sqlCommand = @"SELECT [ConnectionId],[UserId],[MessageBody] from [smart].[Message] where [Date]>@Date";
            using(SqlConnection con = new SqlConnection(ConStr))
            {
                SqlCommand cmd = new SqlCommand(sqlCommand, con);
                cmd.Parameters.AddWithValue("@Date", currentTime);
                if(con.State != System.Data.ConnectionState.Open)
                {
                    con.Open();
                }
                cmd.Notification = null;
                SqlDependency sqlDep = new SqlDependency(cmd);
                sqlDep.OnChange += sqlDep_OnChange;
                using(SqlDataReader reader = cmd.ExecuteReader())
                {

                }
            }

        }

        private void sqlDep_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if(e.Type == SqlNotificationType.Change)
            {
                SqlDependency sqlDep = sender as SqlDependency;
                sqlDep.OnChange -= sqlDep_OnChange;

                var notificationHub = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
                notificationHub.Clients.All.notify("added");

                RegisterNotification(DateTime.Now);
            }
        }

        public List<Message> GetMessage(DateTime afterDate)
        {
            using (SmartHealthEntities sh = new SmartHealthEntities())
            {
                return sh.message.Where(a => a.Date > afterDate).OrderByDescending(a => a.Date).ToList();
            }
        }
    }
}