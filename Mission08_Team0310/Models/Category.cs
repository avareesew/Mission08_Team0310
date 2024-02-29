using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0310.Models;

public class Category
{
    [Key]
    public required int CategoryId { get; set; }

    public required string CategoryName { get; set; }
}
