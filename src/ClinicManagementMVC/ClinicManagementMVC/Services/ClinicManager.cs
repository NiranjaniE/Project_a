using ClinicManagementMVC.Models;
using ClinicManagementMVC.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementMVC.Services
{
    
    public class ClinicManager : IFunction<Doctordetails>, IFunction<Patientdetails>,IFunction<Appointmentfixing>
    {
        private ClinicContext _context;
        private ILogger<ClinicManager> _logger;
        public ClinicManager()
        { }
        public ClinicManager(ClinicContext context, ILogger<ClinicManager> logger)
        {
            _context = context;
            _logger = logger;
        }
        public void Add(Doctordetails t)
        {
            _context.Doctordetails.Add(t);
            _context.SaveChanges();
        }

        public void Add(Patientdetails t)
        {
            _context.PatientTable.Add(t);
            _context.SaveChanges();
        }
        

        public void Add(Appointmentfixing t)
        {
            throw new NotImplementedException();
        }

        public Doctordetails Get(int id)
        {
            try
            {
                Doctordetails doctordetails = _context.Doctordetails.FirstOrDefault(x => x.DoctorID == id);
                return doctordetails;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }
       



        Patientdetails IFunction<Patientdetails>.Get(int id)
        {
            try
            {
                Patientdetails patient = _context.PatientTable.FirstOrDefault(a => a.PatientID == id);
                return patient;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

        Appointmentfixing IFunction<Appointmentfixing>.Get(int id)
        {
            try
            {
                Appointmentfixing appointment = _context.AppointmentTable.FirstOrDefault(a => a.AppointmentId == id);
                return appointment;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }
    }
}
