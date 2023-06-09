﻿using ColoradoBeetle.Domain.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ColoradoBeetle.Application.Products.Queries.GetProductById; 
public class ProductDto {
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public int Volume { get; set; }
    public VolumeUnit VolumeUnit { get; set; }
    public int Weight { get; set; }
    public WeightUnit WeightUnit { get; set; }



}
