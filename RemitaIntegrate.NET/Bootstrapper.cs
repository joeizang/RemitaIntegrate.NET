using System;
using System.Collections.Generic;
using System.Text;
using UnityHelper;
using Unity;

namespace RemitaIntegrate.NET
{
    public class Bootstrapper
    {
        public UnityContainerExtension Container { get; private set; }

        public Bootstrapper()
        {
            
            //Container = new UnityContainerExtension((IUnityContainer) new UnityContainer());
        }
    }
}
