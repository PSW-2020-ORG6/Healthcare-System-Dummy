﻿using System;

namespace HealthClinic.FrontendAdapters
{
    public class PhysitianStats
    {
        private DateTime day;
        private int numOfAppointments;

        public PhysitianStats(DateTime day, int numOfAppointments)
        {
            this.day = day;
            this.numOfAppointments = numOfAppointments;
        }

        public DateTime Day { get => day; set => day = value; }
        public int NumOfAppointments { get => numOfAppointments; set => numOfAppointments = value; }
    }
}
