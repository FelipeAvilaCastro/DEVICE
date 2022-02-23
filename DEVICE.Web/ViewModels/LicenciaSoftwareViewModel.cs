using DEVICE.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVICE.Web.ViewModels
{
    public class LicenciaSoftwareViewModel
    {

        public IEnumerable<Licencia> ListadoLicencia { get; set; }
        public IEnumerable<Software> ListadoSoftware { get; set; }
        public IEnumerable<SoftwareModulo> ListadoSoftwareModulo { get; set; }
        public IEnumerable<SoftwareVersion> ListadoSoftwareVersion { get; set; }

    }
}
