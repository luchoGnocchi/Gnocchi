using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Services.LogServices
{
    public interface ILogService
    {
        /// <summary>
        /// Método encargado de loguear la info de las acciones del usuario
        /// </summary>
        /// <param name="user">nombre del usuario actual</param>     
        /// <param name="action">ubicacion actual Login o Importacion</param>
        /// <param name="message">detalle de accion</param>
        void Info(string user, string action, string message);

        /// <summary>
        /// Método encargado de loguear los errores
        /// </summary>
        /// <param name="user">nombre del usuario actual</param>        
        /// <param name="action">ubicacion actual Login o Importacion</param>
        /// <param name="message">detalle de accion</param>
        void Error(string user, string action, string error);

        /// <summary>
        /// Método encargado de loguear las advertencias
        /// </summary>
        /// <param name="user">nombre del usuario actual</param>       
        /// <param name="action">ubicacion actual Login o Importacion</param>
        /// <param name="message">detalle de accion</param>
        void Warning(string user, string action, string error);

        /// <summary>
        /// Método que permite obtener el log entre dos fechas
        /// </summary>
        /// <param name="dateFrom">fecha desde</param>
        /// <param name="dateTo">fecha hasta</param>       
        List<LogDTO> GetLog(DateTime dateFrom, DateTime dateTo);
    }
}
