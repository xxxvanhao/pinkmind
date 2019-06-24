using Rikkei.PindMind.DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Rikei.PinkMind.Business.Categories.Queries
{
    public class CategoryModel 
    {
    public long ID { get; set; }
    public string Name { get; set; }
    public long CreateBy { get; set; }
    public DateTime CreateAt { get; set; }
    public long UpdateBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public bool DelFlag { get; set; }
    public static Expression<Func<Category, CategoryModel>> Projection
    {
      get
      {
        return category => new CategoryModel
        {
          ID = category.ID,
          Name = category.Name,
          CreateAt = category.CreateAt,
          CreateBy = category.CreateBy,
          UpdateBy = category.UpdateBy,
          LastUpdate = DateTime.UtcNow,
          DelFlag = true
        };
      }
    }
    public static CategoryModel Create(Category category)
    {
      return Projection.Compile().Invoke(category);
    }
  }
}
