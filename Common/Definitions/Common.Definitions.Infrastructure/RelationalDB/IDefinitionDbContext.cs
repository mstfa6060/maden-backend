using Common.Definitions.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Definitions.Infrastructure.RelationalDB;
public interface IDefinitionDbContext
{
    // User-Groups
    DbSet<User> AppUsers { get; set; }
    DbSet<Role> AppRoles { get; set; }
    DbSet<UserRole> UserRoles { get; set; }
    DbSet<Resource> AppResources { get; set; }


}
