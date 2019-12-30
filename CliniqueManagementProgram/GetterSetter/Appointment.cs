using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientedProgram.CliniqueManagementProgram.GetterSetter
{
    class Appointment
    {

        public string DoctorId { set; get; }

        public string AppointmentDateAndTime { set; get; }

        public List<PatientAppointment> GetPatientAppointments { set; get; }

    }
}
