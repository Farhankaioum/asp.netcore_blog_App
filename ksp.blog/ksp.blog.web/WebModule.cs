using Autofac;
using ksp.blog.web.Areas.Admin.Models.BlogViewModel;

namespace ksp.blog.web
{
    public class WebModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public WebModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BlogIndexViewModel>();
            base.Load(builder);
        }
    }
}
