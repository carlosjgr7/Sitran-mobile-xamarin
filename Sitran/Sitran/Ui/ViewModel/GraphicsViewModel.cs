using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Runtime.InteropServices;
using Acr.UserDialogs;
using Microcharts;
using Sitran.Data.Network.Responses;
using Sitran.Domain;
using Sitran.Model;
using SkiaSharp;
using Xamarin.Forms;

namespace Sitran.Ui.ViewModel
{
    public class GraphicsViewModel : BaseViewModel
    {
        private INavigation navigation;

        public Chart ChartObject { get; set; }
        public List<ChartsModelCantidadTransacciones> ChartsTransacciones { get; set; }
        public List<ChartsModelCantidadPosTransando> ChartsPosTransando { get; set; }
        public List<ChartsModelCantidadPosTransando> ChartsMontoTransaccionesAprobadas { get; set; }
        public List<ChartsModelMontoDiario> ChartsMontoMensual { get; set; }
        public PickerModel SelectMonth { get; set; }
        public PickerModel SelectYear { get; set; }
        public List<PickerModel> Month { get; set; } = GetMonthYear.Month;
        public List<PickerModel> Year { get; set; } = GetMonthYear.Year;

        public string BackColorOrg { get; set; } = "#322463";
        public string Organizacion { get; set; } = "Sitran";

        public ObservableCollection<Menuu> MenuItems { get; set; }


        public GraphicsViewModel(INavigation navigation)
        {
            MenuItems = GetMenus();
            this.navigation = navigation;
        }


        private ObservableCollection<Menuu> GetMenus()
        {
            return new ObservableCollection<Menuu>
            {
                new Menuu { Title = "Sitran", Icon = "profile.png" },
                new Menuu { Title = "1000Pagos", Icon = "profile.png" },
                new Menuu{ Title = "CarroPago", Icon = "profile.png" },
                new Menuu { Title = "LibrePago", Icon = "profile.png" }

            };
        }

        private async void getGraphicsByDate(InitDate date)
        {
            UserDialogs.Instance.ShowLoading("Buscando Datos");
            var result = await new GetGraphicsByDate().GetInfoGraphics(date);
            if (result != null)
            {
                if (Organizacion.Equals("Sitran"))
                {
                    UserDialogs.Instance.HideLoading();
                    SetEntriesGraphicsTransacciones(result);
                    SetEntriesGraphicsCantidadPosTransando(result);
                    SetEntriesGraphicsTransaccionesAprobadas(result);
                    SetEntriesGraphicsMontoTotal(result);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    ChartsTransacciones = null;
                    ChartsPosTransando = null;
                    ChartsMontoTransaccionesAprobadas = null;
                    ChartsMontoMensual = null;


                    await Application.Current.MainPage
                   .DisplayAlert("No disponible",
                                  "Sesion en construccion, pruebe con Sitran",
                                  "OK");
                }
            }
            else
            {
                UserDialogs.Instance.HideLoading();
                await Application.Current.MainPage
               .DisplayAlert("DATOS NO ENCONTRADOS",
                              "no existen datos en la fecha indicada",
                              "OK");

            }

        }
        private void SetEntriesGraphicsMontoTotal(ResponseGraphics result)
        {

            List<ChartEntry> entries = new List<ChartEntry>();
            foreach (var item in result.info.totalMontoMesActual)
            {
                entries.Add(new ChartEntry(float.Parse(item.cantidad.ToString().Replace(".", "").Replace(",", ".")))
                {
                    Color = SKColor.Parse("#FF00008B"),
                    Label = item.fecha.ToString(),
                    ValueLabel = item.cantidad.ToString()
                });
            }

            ChartsMontoMensual = new List<ChartsModelMontoDiario>()
            {
                new ChartsModelMontoDiario()
                 {
                     Name = "Montos Diarios",
                     Chart = new LineChart(){Entries = entries,LabelTextSize=28 }
                 }
            };


        }
        private void SetEntriesGraphicsTransaccionesAprobadas(ResponseGraphics result)
        {
            List<ChartEntry> entries = new List<ChartEntry>
            {
                new ChartEntry(((float)result.info.total_transacciones_aprobadas.monto_aprobadas_carropago))
                {
                    Color=SKColor.Parse("#FF00008B"),
                    Label ="",
                    ValueLabel = ""
                },

                new ChartEntry((float)result.info.total_transacciones_aprobadas.monto_aprobadas_librepago)
                {
                    Color=SKColor.Parse("#FF0000"),
                    Label ="",
                    ValueLabel = ""
                },

                new ChartEntry((float)result.info.total_transacciones_aprobadas.monto_aprobadas_milpagos)
                {
                    Color=SKColor.Parse("#008000"),
                    Label ="",
                    ValueLabel = ""
                },

                new ChartEntry((float)result.info.total_transacciones_aprobadas.informacion_bvc)
                {
                    Color=SKColor.Parse("#F6C844"),
                    Label ="",
                    ValueLabel = ""
                },

                new ChartEntry((float)result.info.total_transacciones_aprobadas.informacion_plaza)
                {
                    Color=SKColor.Parse("#FFDEB887"),
                    Label ="",
                    ValueLabel = ""
                },

                new ChartEntry((float)result.info.total_transacciones_aprobadas.informacion_bnc)
                {
                    Color=SKColor.Parse("#FFDC143C"),
                    Label ="",
                    ValueLabel = ""
                },

            };

            ChartsMontoTransaccionesAprobadas = new List<ChartsModelCantidadPosTransando>()
            {
                new ChartsModelCantidadPosTransando
                {
                    Name = "Monto Transacciones Aprobadas",
                    Chart = new BarChart(){Entries = entries },
                    CarroPago = result.info.total_transacciones_aprobadas.monto_aprobadas_carropago.ToString("N0").Replace(",","."),
                    Bnc = result.info.total_transacciones_aprobadas.informacion_bnc.ToString("N0").Replace(",","."),
                    Bvc = result.info.total_transacciones_aprobadas.informacion_bvc.ToString("N0").Replace(",","."),
                    LibrePago = result.info.total_transacciones_aprobadas.monto_aprobadas_librepago.ToString("N0").Replace(",","."),
                    MilPagos = result.info.total_transacciones_aprobadas.monto_aprobadas_milpagos.ToString("N0").Replace(",","."),
                    Plaza = result.info.total_transacciones_aprobadas.informacion_plaza.ToString("N0").Replace(",","."),
                },

                new ChartsModelCantidadPosTransando
                {
                    Name = "Monto Transacciones Aprobadas",
                    Chart = new DonutChart(){Entries = entries },
                    CarroPago = result.info.total_transacciones_aprobadas.monto_aprobadas_carropago.ToString("N0").Replace(",","."),
                    Bnc = result.info.cant_pos_transando.pos_bnc.ToString("N0").Replace(",","."),
                    Bvc = result.info.cant_pos_transando.pos_bvc.ToString("N0").Replace(",","."),
                    LibrePago = result.info.cant_pos_transando.pos_librepago.ToString("N0").Replace(",","."),
                    MilPagos = result.info.cant_pos_transando.pos_milpagos.ToString("N0").Replace(",","."),
                    Plaza = result.info.cant_pos_transando.pos_plaza.ToString("N0").Replace(",","."),
                },

                new ChartsModelCantidadPosTransando
                {
                    Name = "Monto Transacciones Aprobadas",
                    Chart = new PieChart(){Entries = entries },
                    CarroPago = result.info.cant_pos_transando.pos_carropago.ToString("N0").Replace(",","."),
                    Bnc = result.info.cant_pos_transando.pos_bnc.ToString("N0").Replace(",","."),
                    Bvc = result.info.cant_pos_transando.pos_bvc.ToString("N0").Replace(",","."),
                    LibrePago = result.info.cant_pos_transando.pos_librepago.ToString("N0").Replace(",","."),
                    MilPagos = result.info.cant_pos_transando.pos_milpagos.ToString("N0").Replace(",","."),
                    Plaza = result.info.cant_pos_transando.pos_plaza.ToString("N0").Replace(",","."),
                },
            };
        }
        private void SetEntriesGraphicsCantidadPosTransando(ResponseGraphics result)
        {
            List<ChartEntry> entries = new List<ChartEntry>
            {
                new ChartEntry(result.info.cant_pos_transando.pos_carropago)
                {
                    Color=SKColor.Parse("#FF00008B"),
                    Label ="",
                    ValueLabel = ""
                },

                new ChartEntry(result.info.cant_pos_transando.pos_librepago)
                {
                    Color=SKColor.Parse("#FF0000"),
                    Label ="",
                    ValueLabel = ""
                },

                new ChartEntry(result.info.cant_pos_transando.pos_milpagos)
                {
                    Color=SKColor.Parse("#008000"),
                    Label ="",
                    ValueLabel = ""
                },

                new ChartEntry(result.info.cant_pos_transando.pos_bvc)
                {
                    Color=SKColor.Parse("#F6C844"),
                    Label ="",
                    ValueLabel = ""
                },

                new ChartEntry(result.info.cant_pos_transando.pos_plaza)
                {
                    Color=SKColor.Parse("#FFDEB887"),
                    Label ="",
                    ValueLabel = ""
                },

                new ChartEntry(result.info.cant_pos_transando.pos_bnc)
                {
                    Color=SKColor.Parse("#FFDC143C"),
                    Label ="",
                    ValueLabel = ""
                },
            };



            ChartsPosTransando = new List<ChartsModelCantidadPosTransando>()
            {
                new ChartsModelCantidadPosTransando
                {
                    Name = "Cantidad de Pos Transando",
                    Chart = new BarChart(){Entries = entries },
                    CarroPago = result.info.cant_pos_transando.pos_carropago.ToString("N0").Replace(",","."),
                    Bnc = result.info.cant_pos_transando.pos_bnc.ToString("N0").Replace(",","."),
                    Bvc = result.info.cant_pos_transando.pos_bvc.ToString("N0").Replace(",","."),
                    LibrePago = result.info.cant_pos_transando.pos_librepago.ToString("N0").Replace(",","."),
                    MilPagos = result.info.cant_pos_transando.pos_milpagos.ToString("N0").Replace(",","."),
                    Plaza = result.info.cant_pos_transando.pos_plaza.ToString("N0").Replace(",","."),
                },

                new ChartsModelCantidadPosTransando
                {
                    Name = "Cantidad de Pos Transando",
                    Chart = new DonutChart(){Entries = entries },
                    CarroPago = result.info.cant_pos_transando.pos_carropago.ToString("N0").Replace(",","."),
                    Bnc = result.info.cant_pos_transando.pos_bnc.ToString("N0").Replace(",","."),
                    Bvc = result.info.cant_pos_transando.pos_bvc.ToString("N0").Replace(",","."),
                    LibrePago = result.info.cant_pos_transando.pos_librepago.ToString("N0").Replace(",","."),
                    MilPagos = result.info.cant_pos_transando.pos_milpagos.ToString("N0").Replace(",","."),
                    Plaza = result.info.cant_pos_transando.pos_plaza.ToString("N0").Replace(",","."),
                },

                new ChartsModelCantidadPosTransando
                {
                    Name = "Cantidad de Transacciones",
                    Chart = new PieChart(){Entries = entries },
                     CarroPago = result.info.cant_pos_transando.pos_carropago.ToString("N0").Replace(",","."),
                    Bnc = result.info.cant_pos_transando.pos_bnc.ToString("N0").Replace(",","."),
                    Bvc = result.info.cant_pos_transando.pos_bvc.ToString("N0").Replace(",","."),
                    LibrePago = result.info.cant_pos_transando.pos_librepago.ToString("N0").Replace(",","."),
                    MilPagos = result.info.cant_pos_transando.pos_milpagos.ToString("N0").Replace(",","."),
                    Plaza = result.info.cant_pos_transando.pos_plaza.ToString("N0").Replace(",","."),
                },

            };





        }
        private void SetEntriesGraphicsTransacciones(ResponseGraphics result)
        {


            List<ChartEntry> entries = new List<ChartEntry>
            {
                new ChartEntry(result.info.transacciones.aprobadas)
                {
                    Color=SKColor.Parse("#FF00008B"),
                    Label ="",
                    ValueLabel = ""
                },

                 new ChartEntry(result.info.transaccionesAnterior.aprobadas)
                {
                    Color=SKColor.Parse("#FF0000"),
                    Label ="",
                    ValueLabel = ""
                },

                  new ChartEntry(result.info.transacciones.rechazadas)
                {
                    Color=SKColor.Parse("#008000"),
                    Label ="",
                    ValueLabel = ""
                },

                 new ChartEntry(result.info.transaccionesAnterior.rechazadas)
                {
                    Color=SKColor.Parse("#F6C844"),
                    Label ="",
                    ValueLabel = ""
                },
            };

            ChartsTransacciones = new List<ChartsModelCantidadTransacciones>()
            {
                new ChartsModelCantidadTransacciones
                {
                    Name = "Cantidad de Transacciones",
                    Chart = new BarChart(){Entries = entries},
                    CantidadAprobadasEsteMes = result.info.transacciones.aprobadas.ToString("N0").Replace(",","."),
                    CantidadAprobadasMesPasado = result.info.transaccionesAnterior.aprobadas.ToString("N0").Replace(",","."),
                    CantidadRechazadasEsteMes = result.info.transacciones.rechazadas.ToString("N0").Replace(",","."),
                    CantidadRechazadasMesPasado = result.info.transaccionesAnterior.rechazadas.ToString("N0").Replace(",",".")
                },

                new ChartsModelCantidadTransacciones
                {
                    Name = "Cantidad de Transacciones",
                    Chart = new DonutChart(){Entries = entries },
                    CantidadAprobadasEsteMes = result.info.transacciones.aprobadas.ToString("N0").Replace(",","."),
                    CantidadAprobadasMesPasado = result.info.transaccionesAnterior.aprobadas.ToString("N0").Replace(",","."),
                    CantidadRechazadasEsteMes = result.info.transacciones.rechazadas.ToString("N0").Replace(",","."),
                    CantidadRechazadasMesPasado = result.info.transaccionesAnterior.rechazadas.ToString("N0").Replace(",",".")
                },

                new ChartsModelCantidadTransacciones
                {
                    Name = "Cantidad de Transacciones",
                    Chart = new PieChart(){Entries = entries },
                    CantidadAprobadasEsteMes = result.info.transacciones.aprobadas.ToString("N0").Replace(",","."),
                    CantidadAprobadasMesPasado = result.info.transaccionesAnterior.aprobadas.ToString("N0").Replace(",","."),
                    CantidadRechazadasEsteMes = result.info.transacciones.rechazadas.ToString("N0").Replace(",","."),
                    CantidadRechazadasMesPasado = result.info.transaccionesAnterior.rechazadas.ToString("N0").Replace(",",".")
                },

            };



        }

 


        public Command CommandFind => new Command(() =>
        {
            if (SelectMonth != null && SelectYear != null)
            {
                var date = new InitDate() { init = SelectYear.Value + "-" + GetMonthYear.getMonthNumber(SelectMonth.Value) };
                getGraphicsByDate(date);
               
            }

        });


    }



  


}

