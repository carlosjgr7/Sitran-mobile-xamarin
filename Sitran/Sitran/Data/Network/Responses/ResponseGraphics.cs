using System;
using System.Collections.Generic;

namespace Sitran.Data.Network.Responses
{
    public class CantPosTransando
    {
        public int pos_carropago { get; set; }
        public int pos_librepago { get; set; }
        public int pos_milpagos { get; set; }
        public int pos_bvc { get; set; }
        public int pos_plaza { get; set; }
        public int pos_bnc { get; set; }
    }

    public class CantPosTransandoAnterior
    {
        public int pos_carropago { get; set; }
        public int pos_librepago { get; set; }
        public int pos_milpagos { get; set; }
        public int pos_bvc { get; set; }
        public int pos_plaza { get; set; }
        public int pos_bnc { get; set; }
    }

    public class Info
    {
        public List<Value> values { get; set; }
        public Transacciones transacciones { get; set; }
        public TotalTransaccionesAprobadas total_transacciones_aprobadas { get; set; }
        public CantPosTransando cant_pos_transando { get; set; }
        public TransaccionesAnterior transaccionesAnterior { get; set; }
        public TotalTransaccionesAprobadasAnterior total_transacciones_aprobadasAnterior { get; set; }
        public CantPosTransandoAnterior cant_pos_transandoAnterior { get; set; }
        public List<TotalTransMesActual> totalTransMesActual { get; set; }
        public List<TotalTransMesAnterior> totalTransMesAnterior { get; set; }
        public List<TotalMontoMesActual> totalMontoMesActual { get; set; }
        public List<TotalMontoMesAnterior> totalMontoMesAnterior { get; set; }
    }

    public class ResponseGraphics
    {
        public string message { get; set; }
        public Info info { get; set; }
    }

    public class TotalMontoMesActual
    {
        public string cantidad { get; set; }
        public string fecha { get; set; }
    }

    public class TotalMontoMesAnterior
    {
        public string cantidad { get; set; }
        public string fecha { get; set; }
    }

    public class TotalTransaccionesAprobadas
    {
        public double monto_aprobadas_carropago { get; set; }
        public double monto_aprobadas_librepago { get; set; }
        public double monto_aprobadas_milpagos { get; set; }
        public double informacion_bvc { get; set; }
        public double informacion_plaza { get; set; }
        public double informacion_bnc { get; set; }
    }

    public class TotalTransaccionesAprobadasAnterior
    {
        public double monto_aprobadas_carropago { get; set; }
        public double monto_aprobadas_librepago { get; set; }
        public double monto_aprobadas_milpagos { get; set; }
        public double informacion_bvc { get; set; }
        public double informacion_plaza { get; set; }
        public double informacion_bnc { get; set; }
    }

    public class TotalTransMesActual
    {
        public string cantidad { get; set; }
        public string fecha { get; set; }
    }

    public class TotalTransMesAnterior
    {
        public string cantidad { get; set; }
        public string fecha { get; set; }
    }

    public class Transacciones
    {
        public int aprobadas { get; set; }
        public int rechazadas { get; set; }
    }

    public class TransaccionesAnterior
    {
        public int aprobadas { get; set; }
        public int rechazadas { get; set; }
    }

    public class Value
    {
        public string FECHA { get; set; }
        public string TR_APROBADAS { get; set; }
        public string TR_RECHAZADAS { get; set; }
        public string TOTAL_TRANSACCIONES { get; set; }
        public string MONTO_APROBADAS_CARROPAGO { get; set; }
        public string POS_CARROPAGO { get; set; }
        public string MONTO_APROBADAS_LIBREPAGO { get; set; }
        public string POS_LIBREPAGO { get; set; }
        public string MONTO_APROBADAS_1000PAGOS { get; set; }
        public string POS_1000PAGOS { get; set; }
        public string Informacion_BVC { get; set; }
        public string POS_BVC { get; set; }
        public string Informacion_PLAZA { get; set; }
        public string POS_PLAZA { get; set; }
        public string Informacion_BNC { get; set; }
        public string POS_BNC { get; set; }
        public string TOTAL_MONTO_APROBADAS { get; set; }
    }


}

