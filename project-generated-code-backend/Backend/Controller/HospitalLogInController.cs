﻿using health_clinic_class_diagram.Backend.Model.Util;
using health_clinic_class_diagram.Backend.Service.HospitalAccountsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace health_clinic_class_diagram.Backend.Controller
{
    public class HospitalLogInController
    {
        public HospitalLogInService hospitalLogInService;

        public HospitalLogInController()
        {
            hospitalLogInService = new HospitalLogInService();
        }

        public TypeOfUser GetUserType(string jmbg, string password)
        {
            return hospitalLogInService.GetUserType(jmbg, password);
        }
    }
}
