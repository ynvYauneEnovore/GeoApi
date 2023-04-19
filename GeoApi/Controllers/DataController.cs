using GeoApi.Data;
using Microsoft.AspNetCore.Mvc;
using GeoData.Models;

namespace GeoData.Controlador
{
    public class EnvioController : Controller
    {
        private readonly MvcDataContext _context;

        public EnvioController(MvcDataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Guardar([FromBody] GeoData data)
        {
            // Lógica para procesar los datos recibidos y guardarlos en la base de datos

            // Crear un objeto GeoDataModel para guardar los datos recibidos
            var datosModel = new GeoData
            {
                ip = data.ip,
                name = data.name,
                currency = data.currency,
                currency_name = data.currency_name,
                currency_symbol = data.currency_symbol
            };

            // Guardar el objeto en la base de datos
            _context.GeoData.Add(datosModel);
            _context.SaveChanges();

            // Mostrar los datos guardados en la consola
            Console.WriteLine("Datos recibidos y guardados en la base de datos correctamente:");
            Console.WriteLine($"IP: {datosModel.ip}");
            Console.WriteLine($"Name: {datosModel.name}");
            Console.WriteLine($"Currency: {datosModel.currency}");
            Console.WriteLine($"Currency Name: {datosModel.currency_name}");
            Console.WriteLine($"Currency Symbol: {datosModel.currency_symbol}");

            // Devolver una respuesta JSON con los datos procesados
            return Json(new
            {
                Resultado = "Datos recibidos y guardados en la base de datos correctamente",
                Datos = datosModel
            });
        }
    }
}
