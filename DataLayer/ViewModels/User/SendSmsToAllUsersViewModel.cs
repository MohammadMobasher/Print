﻿using DataLayer.SSOT;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.ViewModels.User
{
    public class SendSmsToAllUsersViewModel
    {
        public string Message { get; set; }

        public FilterUserSSOT SendType { get; set; }
    }
}
