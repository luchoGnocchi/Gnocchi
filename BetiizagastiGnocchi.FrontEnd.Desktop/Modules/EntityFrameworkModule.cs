using Autofac;
using BetizagastiGnocchi.BackEnd.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BetizagastiGnocchi.FrontEnd.Desktop.Modules
{
    public class EntityFrameworkModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(CarManagementContext)).As(typeof(DbContext)).InstancePerLifetimeScope();     
        }
    }
}