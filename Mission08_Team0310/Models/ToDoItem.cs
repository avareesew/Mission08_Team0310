using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Team0310.Models;

public class ToDoItem
{
    [Key]
    public required int TaskId { get; set; }

    public required string TaskName { get; set; }

    public string? DueDate { get; set; }

    public required int Quadrant { get; set; }

    public int? Completed { get; set; }

    [ForeignKey("CategoryID")]
    public int? CategoryID { get; set; }
    public Category? Category { get; set; }
}
