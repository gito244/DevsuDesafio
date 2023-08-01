using AutoMapper;
using Devsu.Application.Features.Operaciones.Clientes.Commands.CreateCliente;
using Devsu.Application.Features.Operaciones.Clientes.Commands.UpdateCliente;
using Devsu.Application.Features.Operaciones.Clientes.Queries.Vms;
using Devsu.Application.Features.Operaciones.Cuentas.Commands.CreateCuenta;
using Devsu.Application.Features.Operaciones.Cuentas.Commands.UpdateCuenta;
using Devsu.Application.Features.Operaciones.Cuentas.Queries.Vms;
using Devsu.Application.Features.Operaciones.Movimientos.Commands.CreateMovimiento;
using Devsu.Application.Features.Operaciones.Movimientos.Commands.UpdateMovimiento;
using Devsu.Application.Features.Operaciones.Movimientos.Queries.Vms;
using Devsu.Application.Features.Operaciones.Personas.Commands.CreatePersona;
using Devsu.Application.Features.Operaciones.Personas.Commands.UpdatePersona;
using Devsu.Domain.Operaciones;

namespace Devsu.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movimientos, MovimientosWithIncludesVmResponse>()
                .ForMember(p => p.Fecha, x => x.MapFrom(a => a.Fecha.ToString("yyyy-MM-dd")))
                .ForMember(p => p.NumeroCuenta, x => x.MapFrom(a => a.NumeroCuenta))
                .ForMember(p => p.Tipo, x => x.MapFrom(a => a.NumeroCuentaNavigation.TipoCuenta))
                .ForMember(p => p.SaldoInicial, x => x.MapFrom(a => a.NumeroCuentaNavigation.SaldoInicial))
                .ForMember(p => p.Estado, x => x.MapFrom(a => a.NumeroCuentaNavigation.Estado))
                .ForMember(p => p.Movimiento, x => x.MapFrom(a => a.Valor))
                .ForMember(p => p.SaldoDisponible, x => x.MapFrom(a => a.Saldo))
                .ForMember(p => p.Cliente, x => x.MapFrom(a => a.NumeroCuentaNavigation.Cliente.Persona.Nombre));

            CreateMap<Cliente, ClienteWithIncludeVmResponse>()
                .ForMember(p => p.Nombres, x => x.MapFrom(a => a.Persona.Nombre))
                .ForMember(p => p.Direccion, x => x.MapFrom(a => a.Persona.Direccion))
                .ForMember(p => p.Telefono, x => x.MapFrom(a => a.Persona.Telefono))
                .ForMember(p => p.Contrasena, x => x.MapFrom(a => a.Contrasena))
                .ForMember(p => p.Estado, x => x.MapFrom(a => a.Estado));

            CreateMap<Cuenta, CuentaWithIncludeVmResponse>()
                .ForMember(p => p.NumeroCuenta, x => x.MapFrom(a => a.NumeroCuenta))
                .ForMember(p => p.Tipo, x => x.MapFrom(a => a.TipoCuenta))
                .ForMember(p => p.SaldoInicial, x => x.MapFrom(a => a.SaldoInicial))
                .ForMember(p => p.Estado, x => x.MapFrom(a => a.Estado))
                .ForMember(p => p.Cliente, x => x.MapFrom(a => a.Cliente.Persona.Nombre));


            CreateMap<CreatePersonaCommand, Persona>();
            CreateMap<UpdatePersonaCommand, Persona>();
            CreateMap<CreateClienteCommand, Cliente>();
            CreateMap<UpdateClienteCommand,Cliente>();
            CreateMap<CreateCuentaCommand, Cuenta>();
            CreateMap<UpdateCuentaCommand,Cuenta>();
            CreateMap<CreateMovimientosCommand, Movimientos>();
            CreateMap<UpdateMovimientoCommand, Movimientos>();
        }
    }
}
