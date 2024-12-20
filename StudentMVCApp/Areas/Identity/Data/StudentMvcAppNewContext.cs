﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StudentMVCAppNew.Data;

public class StudentMvcAppNewContext : IdentityDbContext<ApplicationUser>
{
    public StudentMvcAppNewContext(DbContextOptions<StudentMvcAppNewContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
