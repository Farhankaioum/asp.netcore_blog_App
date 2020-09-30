using Autofac;

namespace ksp.blog.framework
{
    public class FrameworkModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public FrameworkModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<FrameworkContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BlogUnitOfWork>().As<IBlogUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CategoryService>().As<ICategoryService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BlogRepository>().As<IBlogRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BlogService>().As<IBlogService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
