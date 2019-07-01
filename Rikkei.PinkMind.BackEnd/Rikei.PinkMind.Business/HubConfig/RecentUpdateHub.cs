using Microsoft.AspNetCore.SignalR;
using Rikkei.PindMind.DAO.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.HubConfig
{
  public class RecentUpdateHub : Hub
  {
    public async Task BroadcastChartData(ReUpdateSpace data) => await Clients.All.SendAsync("broadcastchartdata", data);
  }
}
