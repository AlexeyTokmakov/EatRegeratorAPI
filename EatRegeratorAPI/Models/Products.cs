using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EatRegeratorAPI
{
  public partial class Products
  {
    public Products()
    {
      Product2Dishs = new List<Product2Dishs>();
    }
    public Guid ProductGuid { get; set; }
    public string Name { get; set; }
    public virtual List<Product2Dishs> Product2Dishs { get; set; }
  }
}
