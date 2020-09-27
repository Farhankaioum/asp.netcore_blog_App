using Autofac;
using ksp.blog.membership.Contexts;
using ksp.blog.membership.Entities;
using ksp.blog.membership.Services;
using Microsoft.AspNetCore.Identity;

namespace ksp.blog.membership
{
    public class MembershipModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public MembershipModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<ApplicationDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<MembershipRepository>().As<IMembershipRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<MembershipUnitOfWork>().As<IMembershipUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<MembershipService>().As<IMembershipService>()
                .InstancePerLifetimeScope();

            //builder.RegisterType<UserManager>().As<UserManager<ApplicationUser>>()
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<SignInManager>().As<SignInManager<ApplicationUser>>()
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<RoleManager>().As<RoleManager<Role>>();



            base.Load(builder);
        }
    }
}
