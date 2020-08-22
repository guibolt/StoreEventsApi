using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StoreEvents.Application.Queries.GetCupom;
using StoreEvents.Core.Entitites;
using StoreEvents.Core.Repository;
using StoreEvents.Infrastructure.EntityContext;
using StoreEvents.Infrastructure.Repositories;

namespace StoreEvents.Api.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddMediatR(typeof(GetCuponQuery));

            //Sql
            services.AddDbContext<StoreEventsContext>(options => options.UseSqlServer(Configuration.GetConnectionString("StringConexao")), ServiceLifetime.Singleton);

            //repo
            services.AddTransient<IGenericRepository<Cupom>, CupomRepository>();
            services.AddTransient<IGenericRepository<Promocao>, PromocaoRepository>();

        }
    }
 
}
