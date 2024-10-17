using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace MyAspNetCoreApp.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRepositories(this IServiceCollection services, Assembly assembly)
        {
            var types = assembly.GetTypes();

            // 查找所有 Repository 类
            var repositories = types.Where(t => t.IsClass && t.Name.EndsWith("Repository"));
            foreach (var repository in repositories)
            {
                // 查找实现的接口
                var implementedInterfaces = repository.GetInterfaces().FirstOrDefault(i => i.Name == "I" + repository.Name);

                if (implementedInterfaces != null)
                {
                    // 将 Repository 实现类和接口注册为 Scoped
                    services.AddScoped(implementedInterfaces, repository);
                }
            }
        }
    }
}