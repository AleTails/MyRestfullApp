namespace MyRestfullApp.API.Dtos
{
    public class CotizacionDto
    {
        public CotizacionDto(string[] cotizacion)
        {
            Compra = float.Parse(cotizacion[0]);
            Venta = float.Parse(cotizacion[1]);
            LastUpdated = cotizacion[2];
        }
        public float Compra { get; set; }
        public float Venta { get; set; }
        public string LastUpdated { get; set; }
    }
}
