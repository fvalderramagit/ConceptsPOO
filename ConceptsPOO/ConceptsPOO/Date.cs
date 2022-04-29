using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptsPOO
{
    public class Date
    {
        private int _year;
        private int _month;
        private int _day;

        public Date(int year, int month, int day)
        {
            _year = year;
            _month = CheckMonth(month);
            _day = CheckDay(year, month, day);
        }


        //Este metodo valida los dias, teniendo en cuenta los años biciestos
        private int CheckDay(int year, int month, int day)
        {
            if (month == 2 && day == 29 && IsLeapYear(year))
            {
                return day;
            }

            int[] daysPerMonth = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (day >= 1 && day <= daysPerMonth[month])
            {
                return day;
            }

            throw new DayException("Invalid day");
        }


        //Este metodo valida si el año es biciesto
        private bool IsLeapYear(int year)
        {
            //La forma mas optima seria
            return year % 400 == 0 || year % 4 == 0 && year % 100 != 0;

            //// valida si el año es multiplo de 4
            //if (year % 4 == 0)
            //{
            //    // valida si el año es multiplo de 100
            //    if (year % 100 == 0)
            //    {
            //        if (year % 400 == 0)
            //        {
            //            return true;
            //        }
            //        else
            //        {
            //            return false;
            //        }
            //    }
            //    else
            //    {
            //        return true;
            //    }
            //}
            //else
            //{
            //    return false;
            //}




        }

        //Esta funcion valida el mes, que este entre 1 y 12
        private int CheckMonth(int month)
        {
            if (month >= 1 &&  month <= 12)
            {
                return month;
            }

            //Para que mi logica no intervenga con mi intefax de usuario no puedo devolver un mensaje, para ello entonces creo una clase MonthException
            throw new MonthException("Invalid month");
        }

        public override string ToString()
        {
            //de la manera rustica
            //return _year + "/" + _month + "/" + "/" + _day; 

            //con interpolación de string, se pone 00 para que imprima 0 presediendo a los mese y dias de un digito
            return $"{_year}/{_month:00}/{_day:00}";
        }


    }
}
