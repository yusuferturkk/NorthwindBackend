using NorthwindBackend.CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.EntityLayer.Concrete
{
    public class Category : IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
