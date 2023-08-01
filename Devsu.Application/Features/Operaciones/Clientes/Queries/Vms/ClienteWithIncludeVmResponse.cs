namespace Devsu.Application.Features.Operaciones.Clientes.Queries.Vms
{
    public class ClienteWithIncludeVmResponse
    {
        public string? Nombres { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Contrasena { get; set; }
        public bool? Estado { get; set; }
    }
}
