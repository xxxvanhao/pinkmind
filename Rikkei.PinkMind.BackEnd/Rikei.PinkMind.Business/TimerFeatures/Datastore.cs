using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rikei.PinkMind.Business.ReUpdate.GetDetails;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.TimerFeatures
{
  public class Datastore
  {

    private readonly PinkMindContext _pmContext;
    private readonly IMapper _mapper; 
    public Datastore(PinkMindContext pinkMindContext, IMapper mapper)
    {

      _pmContext = pinkMindContext;
      _mapper = mapper;
    }
    public static List<ChartModel> GetData()
    {
      var r = new Random();
      return new List<ChartModel>()
        {
           new ChartModel { Data = new List<int> { r.Next(1, 40) }, Label = "Data1" },
           new ChartModel { Data = new List<int> { r.Next(1, 40) }, Label = "Data2" },
           new ChartModel { Data = new List<int> { r.Next(1, 40) }, Label = "Data3" },
           new ChartModel { Data = new List<int> { r.Next(1, 40) }, Label = "Data4" }
        };
    }
  }
}
