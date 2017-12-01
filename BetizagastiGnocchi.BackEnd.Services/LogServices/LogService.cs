using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Services.LogServices
{
    public class LogService : ILogService
    {
        private string _path;
        private string _folder = "C:\\Lucho\\";
      
        public LogService()
        {          
            var fileName = "Log_" + DateTime.Now.ToString("dd-MM-yy") + ".txt";
            _path = _folder + fileName;
            if (!Directory.Exists(_folder))
            {
                Directory.CreateDirectory(_folder);
            }
            if (!File.Exists(_path))
            {
                using (FileStream fs = File.Create(_path))
                {                 
                }
                WriteLine("CREATE LOG FILE");
            }
        }
              
        public void Error(string user, string action, string error)
        {
            WriteLine("ERROR|User:" + user + "|Action:" + action + "|Message:" + error);
        }

        public void Info(string user, string action, string message)
        {
            WriteLine("INFO|User:" + user + "|Action:" + action + "|Message:" + message);
        }

        public void Warning(string user, string action, string message)
        {
            WriteLine("WARNING|User:" + user + "|Action:" + action + "|Message:" + message);
        }

        private void WriteLine( string line)
        {
            using (StreamWriter file = new StreamWriter(@_path, true))
            {
                file.WriteLine("Fecha:"+DateTime.Now + "|" +  line);
            }
        }

        public List<LogDTO> GetLog(DateTime dateFrom, DateTime dateTo)
        {
            List<LogDTO> logs = new List<LogDTO>();
            if (Directory.Exists(_folder))
            {
                string[] fileEntries = Directory.GetFiles(_folder);                
                foreach (string fileName in fileEntries)
                    logs.AddRange(ProcessFile(fileName, dateFrom, dateTo));
            }
            return logs;
        }

        private List<LogDTO> ProcessFile(string fileName, DateTime dateFrom, DateTime dateTo)
        {
            List<LogDTO> logs = new List<LogDTO>();
            try
            {
                string[] extensionSplit = fileName.Split('.');
                string[] nameSplit = extensionSplit[1].Split('_');
                string dateLogStr = nameSplit[1];
                DateTime dateLog = DateTime.Parse(dateLogStr.ToString());
                if (dateLog >= dateFrom && dateLog <= dateTo)
                {                    
                    string[] lines = File.ReadAllLines(@fileName);
                    foreach (string line in lines)
                    {
                        LogDTO log = new LogDTO();
                        string[] lineSplit = line.Split('|');
                        for (int i = 0; i < lineSplit.Length; i++)
                        {
                            string[] dataSplit = lineSplit[i].Split(':');
                            switch (i)
                            {
                                case 0:
                                    log.Date = dataSplit[1] + ":" + dataSplit[2] + ":" + dataSplit[3];
                                    break;
                                case 1:
                                    log.Type = dataSplit[0];
                                    break;
                                case 2:
                                    log.User = dataSplit[1];
                                    break;
                                case 3:
                                    log.Action = dataSplit[1];
                                    break;
                                case 4:
                                    log.Message = dataSplit[1];
                                    break;
                                default:
                                    break;
                            }
                        }
                        logs.Add(log);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;   //Si da algun error no tomo encuenta ese log
            }
            return logs;
        }

    }
}
