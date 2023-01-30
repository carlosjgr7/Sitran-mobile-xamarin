using System;
using Microcharts;
using System.Collections.Generic;

namespace Sitran.Model
{
	public class ChartsModelCantidadTransacciones
	{
		public String Name { get; set; }
		public Chart Chart { get; set; }
		public String CantidadAprobadasEsteMes { get; set; }
        public String CantidadAprobadasMesPasado { get; set; }
        public String CantidadRechazadasEsteMes { get; set; }
        public String CantidadRechazadasMesPasado { get; set; }
	}

    public class ChartsModelCantidadPosTransando
    {
        public String Name { get; set; }
        public Chart Chart { get; set; }
        public String CarroPago { get; set; }
        public String LibrePago { get; set; }
        public String MilPagos { get; set; }
        public String Bvc { get; set; }
        public String Plaza { get; set; }
        public String Bnc { get; set; }

    }

    public class ChartsModelMontoDiario
    {
        public String Name { get; set; }
        public Chart Chart { get; set; }


    }
}

