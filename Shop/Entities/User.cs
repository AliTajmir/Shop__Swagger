﻿namespace Core.Entities;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Mobile { get; set; }

    public virtual IEnumerable<Order> Orders { get; set; }
}