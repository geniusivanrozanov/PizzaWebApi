﻿using System.ComponentModel.DataAnnotations;

namespace PizzaWebApi.Models;

public class Pizza
{
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Price { get; set; }

}
