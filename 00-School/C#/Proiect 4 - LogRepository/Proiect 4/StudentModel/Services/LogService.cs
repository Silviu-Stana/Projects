using Entities;
using LoggingRepository;
using System;
using System.Collections.Generic;

namespace Services
{
    public class LogService
    {
        private readonly IRepository<Log> _logRepository;

        public LogService(IRepository<Log> logRepository)
        {
            _logRepository = logRepository;
        }

        public void CreateLog(Log log)
        {
            log.LogDate = DateTime.Now.ToString();
            _logRepository.Create(log);
        }

        public void UpdateLog(Log log)
        {
            _logRepository.Update(log);
        }

        public void DeleteLog(int id)
        {
            _logRepository.Delete(id);
        }

        public Log GetLogById(int id)
        {
            return _logRepository.GetById(id);
        }

        public List<Log> GetAllLogs()
        {
            return _logRepository.GetAll();
        }
    }
}
