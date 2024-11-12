using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Common;

public static class PersianTool
{
    private static readonly string[] Pn = { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };
    private static readonly string[] En = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
    public static string ToEnglishNumber(this string strNum)
    {
        var cash = strNum;
        for (var i = 0; i < 10; i++)
            cash = cash.Replace(Pn[i], En[i]);
        return cash;
    }
    public static DateTime ToGeorgianDateTime(this string persianDate)
    {
        try
        {
            persianDate = persianDate.ToEnglishNumber();
            var year = Convert.ToInt32(persianDate.Substring(0, 4));
            var month = Convert.ToInt32(persianDate.Substring(4, 2));
            var day = Convert.ToInt32(persianDate.Substring(6, 2));
            return new DateTime(year, month, day, new PersianCalendar());
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    public static bool PersianDateCorrectFormat(string date)
    {
        try
        {
            ToGeorgianDateTime(date);

            return true;
        }
        catch (Exception)
        {

            return false;
        }
    }
    public static string ToFarsi(this DateTime? date)
    {
        try
        {
            if (date != null) return date.Value.ToFarsi();
        }
        catch (Exception)
        {
            return "";
        }

        return "";
    }

    public static string ToFarsi(this DateTime date)
    {
        if (date == new DateTime()) return "";
        var pc = new PersianCalendar();
        return $"{pc.GetYear(date)}{pc.GetMonth(date):00}{pc.GetDayOfMonth(date):00}";
    }

    public static string ToFarsiHoure(this DateTime date)
    {
        string minute = date.Minute > 9 ? date.Minute.ToString() : "0" + (date.Minute).ToString();
        return $"{date.Hour.ToString()}:{minute}";
    }

    public static bool PersionDateValidation(string persianDate)
    {
        bool status = true;

        try
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            var dateParts = persianDate.Split(new char[] { '/' }).Select(d => int.Parse(d)).ToArray();
            var date = persianCalendar.ToDateTime(dateParts[0], dateParts[1], dateParts[2], 0, 0, 0, 0);
            if (date > DateTime.Now)
            {
                status = false;
            }

        }
        catch (Exception ex)
        {
            status = false;
        }

        return status;
    }

    public static bool PersionTimeValidation(string persianTime)
    {
        bool status = true;

        try
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            var dateParts = persianTime.Split(new char[] { ':' }).Select(d => int.Parse(d)).ToArray();
            var date = persianCalendar.ToDateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, dateParts[0], dateParts[1], 0, 0);
        }
        catch (Exception ex)
        {
            status = false;
        }

        return status;
    }

}