﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_4335.Class
{
    public interface IJsonDataService
    {
        (bool success, int count) ImportJsonData(string json);
    }
}