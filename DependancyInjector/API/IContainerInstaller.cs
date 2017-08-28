﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependancyInjector.API
{
    public interface IContainerInstaller
    {
        void Install(IContainer container, IConfigure config);
    }
}
