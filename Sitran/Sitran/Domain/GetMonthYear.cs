using System;
using Sitran.Model;
using System.Collections.Generic;

namespace Sitran.Domain
{
	public static class GetMonthYear
	{
        public static List<PickerModel> Month { get; set; } = new List<PickerModel>()
        {
            new PickerModel(){Key = 0, Value="Enero" },
            new PickerModel(){Key = 1, Value="Febrero" },
            new PickerModel(){Key = 2, Value="Marzo" },
            new PickerModel(){Key = 3, Value="Abril" },
            new PickerModel(){Key = 4, Value="Mayo" },
            new PickerModel(){Key = 5, Value="Junio" },
            new PickerModel(){Key = 6, Value="Julio" },
            new PickerModel(){Key = 7, Value="Agosto" },
            new PickerModel(){Key = 8, Value="Sptiembre" },
            new PickerModel(){Key = 7, Value="Octubre" },
            new PickerModel(){Key = 7, Value="Noviembre" },
            new PickerModel(){Key = 7, Value="Diciembre" },

        };

        public static List<PickerModel> Year { get;  set; } = new List<PickerModel>()
        {
            new PickerModel(){Key = 0, Value="2017" },
            new PickerModel(){Key = 1, Value="2018" },
            new PickerModel(){Key = 2, Value="2019" },
            new PickerModel(){Key = 3, Value="2020" },
            new PickerModel(){Key = 4, Value="2021" },
            new PickerModel(){Key = 5, Value="2022" },
            new PickerModel(){Key = 6, Value="2023" },
            new PickerModel(){Key = 7, Value="2024" },
            new PickerModel(){Key = 8, Value="2025" },
            new PickerModel(){Key = 7, Value="2026" },
            new PickerModel(){Key = 7, Value="2027" },
            new PickerModel(){Key = 7, Value="2028" },
            new PickerModel(){Key = 8, Value="2029" },
            new PickerModel(){Key = 7, Value="2030" },
            new PickerModel(){Key = 7, Value="2031" },
            new PickerModel(){Key = 7, Value="2032" },

        };

        public static String getMonthNumber(String month)
        {
            switch (month)
            {
                case "Enero": return "01";
                case "Febrero": return "02";
                case "Marzo": return "03";
                case "Abril": return "04";
                case "Mayo": return "05";
                case "Junio": return "06";
                case "Julio": return "07";
                case "Agosto": return "08";
                case "Septiembre": return "09";
                case "Octubre": return "10";
                case "Noviembre": return "11";
                case "Diciembre": return "12";
                default:
                    return "01";
            }
        }

    }
}

