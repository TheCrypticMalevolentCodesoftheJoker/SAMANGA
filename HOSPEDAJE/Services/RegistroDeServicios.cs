using HOSPEDAJE.Services.AutoMapper;
using HOSPEDAJE.Services.PatronUnitOfWork;

using HOSPEDAJE.Areas.ClienteArea.Repository;
using HOSPEDAJE.Areas.ClienteArea.Services;
using HOSPEDAJE.Areas.ClienteArea.Services.MicroServices.ClienteBcrypt;
using HOSPEDAJE.Areas.ClienteArea.Services.MicroServices.ClienteCRUD.CreateMS;
using HOSPEDAJE.Areas.ClienteArea.Services.MicroServices.ClienteCRUD.ReadMS;
using HOSPEDAJE.Areas.ClienteArea.Services.MicroServices.ClienteCRUD.UpdateMS;
using HOSPEDAJE.Areas.ClienteArea.Services.MicroServices.ClienteCRUD.DeleteMS;

using HOSPEDAJE.Areas.UsuarioArea.Repository;
using HOSPEDAJE.Areas.UsuarioArea.Services;
using HOSPEDAJE.Areas.UsuarioArea.Services.MicroServices.UsuarioBcrypt;
using HOSPEDAJE.Areas.UsuarioArea.Services.MicroServices.UsuarioCRUD.CreateMS;
using HOSPEDAJE.Areas.UsuarioArea.Services.MicroServices.UsuarioCRUD.ReadMS;
using HOSPEDAJE.Areas.UsuarioArea.Services.MicroServices.UsuarioCRUD.UpdateMS;
using HOSPEDAJE.Areas.UsuarioArea.Services.MicroServices.UsuarioCRUD.DeleteMS;

using HOSPEDAJE.Areas.HabitacionArea.Repository;
using HOSPEDAJE.Areas.HabitacionArea.Services;
using HOSPEDAJE.Areas.HabitacionArea.Services.MicroServices.HabitacionCRUD.CreateMS;
using HOSPEDAJE.Areas.HabitacionArea.Services.MicroServices.HabitacionCRUD.ReadMS;
using HOSPEDAJE.Areas.HabitacionArea.Services.MicroServices.HabitacionCRUD.UpdateMS;
using HOSPEDAJE.Areas.HabitacionArea.Services.MicroServices.HabitacionCRUD.DeleteMS;

using HOSPEDAJE.Areas.ReservaArea.Repository;
using HOSPEDAJE.Areas.ReservaArea.Services;
using HOSPEDAJE.Areas.ReservaArea.Services.MicroServices.GestorCorreo;
using HOSPEDAJE.Areas.ReservaArea.Services.MicroServices.ReservaCRUD.CreateMS;
using HOSPEDAJE.Areas.ReservaArea.Services.MicroServices.ReservaCRUD.ReadMS;
using HOSPEDAJE.Areas.ReservaArea.Services.MicroServices.ReservaCRUD.UpdateMS;
using HOSPEDAJE.Areas.ReservaArea.Services.MicroServices.ReservaCRUD.DeleteMS;

using HOSPEDAJE.Areas.ListaEsperaArea.Repository;
using HOSPEDAJE.Areas.ListaEsperaArea.Services;
using HOSPEDAJE.Areas.ListaEsperaArea.Services.MicroServices.ListaEsperaCRUD.CreateMS;
using HOSPEDAJE.Areas.ListaEsperaArea.Services.MicroServices.ListaEsperaCRUD.ReadMS;
using HOSPEDAJE.Areas.ListaEsperaArea.Services.MicroServices.ListaEsperaCRUD.UpdateMS;
using HOSPEDAJE.Areas.ListaEsperaArea.Services.MicroServices.ListaEsperaCRUD.DeleteMS;




namespace HOSPEDAJE.Services
{
    public static class RegistroDeServicios
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            // CONFIGURACIÓN DE CONTROLADORES Y VISTAS
            services.AddControllersWithViews(options =>
            {
                // Desactivar los validadores de modelo predeterminados de ASP.NET
                options.ModelValidatorProviders.Clear();
            });

            // REGISTRO DE SERVICIOS COMUNES
            services.AddHttpClient();
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // CLIENTE
                // INYECCIÓN DE REPOSITORIOS
                services.AddScoped<IClienteRepository, ClienteRepository>();

                // INYECCIÓN DE SERVICIOS
                services.AddScoped<IClienteService, ClienteService>();

            // INYECCIÓN DE MICROSERVICIOS
                services.AddScoped<IBcryptCliente, BcryptCliente>();
                services.AddScoped<ICreateClienteMS, CreateClienteMS>();
                services.AddScoped<IReadClienteMS, ReadClienteMS>();
                services.AddScoped<IUpdateClienteMS, UpdateClienteMS>();
                services.AddScoped<IDeleteClienteMS, DeleteClienteMS>();

            // USUARIO
                // INYECCIÓN DE REPOSITORIOS
                services.AddScoped<IUsuarioRepository, UsuarioRepository>();

                // INYECCIÓN DE SERVICIOS
                services.AddScoped<IUsuarioService, UsuarioService>();

                // INYECCIÓN DE MICROSERVICIOS
                services.AddScoped<IBcryptUsuario, BcryptUsuario>();
                services.AddScoped<ICreateUsuarioMS, CreateUsuarioMS>();
                services.AddScoped<IReadUsuarioMS, ReadUsuarioMS>();
                services.AddScoped<IUpdateUsuarioMS, UpdateUsuarioMS>();
                services.AddScoped<IDeleteUsuaerioMS, DeleteUsuaerioMS>();

            // HABITACION
                // INYECCIÓN DE REPOSITORIOS
                services.AddScoped<IHabitacionRepository, HabitacionRepository>();

                // INYECCIÓN DE SERVICIOS
                services.AddScoped<IHabitacionService, HabitacionService>();

                // INYECCIÓN DE MICROSERVICIOS
                services.AddScoped<ICreateHabitacionMS, CreateHabitacionMS>();
                services.AddScoped<IReadHabitacionMS, ReadHabitacionMS>();
                services.AddScoped<IUpdateHabitacionMS, UpdateHabitacionMS>();
                services.AddScoped<IDeleteHabitacionMS, DeleteHabitacionMS>();

            // RESERVA
                // INYECCIÓN DE REPOSITORIOS
                services.AddScoped<IReservaRepository, ReservaRepository>();

                // INYECCIÓN DE SERVICIOS
                services.AddScoped<IReservaService, ReservaService>();

                // INYECCIÓN DE MICROSERVICIOS
                services.AddScoped<IGestorCorreo, GestorCorreo>();
                services.AddScoped<ICreateReservaMS, CreateReservaMS>();
                services.AddScoped<IReadReservaMS, ReadReservaMS>();
                services.AddScoped<IUpdateReservaMS, UpdateReservaMS>();
                services.AddScoped<IDeleteReservaMS, DeleteReservaMS>();

            //LISTA ESPERA
                // INYECCIÓN DE REPOSITORIOS
                services.AddScoped<IListaEsperaRepository, ListaEsperaRepository>();

                // INYECCIÓN DE SERVICIOS
                services.AddScoped<IListaEsperaService, ListaEsperaService>();

                // INYECCIÓN DE MICROSERVICIOS
                services.AddScoped<ICreateListaEsperaMS, CreateListaEsperaMS>();
                services.AddScoped<IReadListaEsperaMS, ReadListaEsperaMS>();
                services.AddScoped<IUpdateListaEsperaMS, UpdateListaEsperaMS>();
                services.AddScoped<IDeleteListaEsperaMS, DeleteListaEsperaMS>();
        }
    }
}
