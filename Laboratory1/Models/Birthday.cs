using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMA.CSharp2024.Laboratory1.Models
{
    internal class Birthday
    {
        public enum ChineseZodiac
        {
            Rat, Ox, Tiger, Rabbit, Dragon, Snake, Horse, Goat, Monkey, Rooster, Dog, Pig
        }
        public enum WesternZodiac
        {
            Aries, Taurus, Gemini, Cancer, Leo, Virgo, Libra, Scorpio, Sagittarius, Capricorn, Aquarius, Pisces
        }

        private DateTime? _birthday;
        private ChineseZodiac _chineseZod;
        private WesternZodiac _westernZod;
        private int _age = -1;

        public DateTime? BirthdayDate 
        {
            get
            {
                return _birthday;
            }
            set
            {
                _birthday = value;
                if (_birthday != null)
                {
                    Age = CalculateAge((DateTime)_birthday);
                    ChineseZod = GetChineseZodiac((DateTime)_birthday);
                    WesternZod = GetWesternZodiac((DateTime)_birthday);
                }
            }
        }

        public ChineseZodiac ChineseZod
        {
            get { return _chineseZod; }
            set { _chineseZod = value; }
        }

        public WesternZodiac WesternZod
        {
            get { return _westernZod; }
            set { _westernZod = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public WesternZodiac GetWesternZodiac(DateTime birthday)
        {
            int month = birthday.Month;
            int day = birthday.Day;

            switch (month)
            {
                case 1: return day <= 20 ? WesternZodiac.Capricorn : WesternZodiac.Aquarius;
                case 2: return day <= 19 ? WesternZodiac.Aquarius : WesternZodiac.Pisces;
                case 3: return day <= 20 ? WesternZodiac.Pisces : WesternZodiac.Aries;
                case 4: return day <= 20 ? WesternZodiac.Aries : WesternZodiac.Taurus;
                case 5: return day <= 21 ? WesternZodiac.Taurus : WesternZodiac.Gemini;
                case 6: return day <= 21 ? WesternZodiac.Gemini : WesternZodiac.Cancer;
                case 7: return day <= 23 ? WesternZodiac.Cancer : WesternZodiac.Leo;
                case 8: return day <= 23 ? WesternZodiac.Leo : WesternZodiac.Virgo;
                case 9: return day <= 23 ? WesternZodiac.Virgo : WesternZodiac.Libra;
                case 10: return day <= 23 ? WesternZodiac.Libra : WesternZodiac.Scorpio;
                case 11: return day <= 22 ? WesternZodiac.Scorpio : WesternZodiac.Sagittarius;
                case 12: return day <= 21 ? WesternZodiac.Sagittarius : WesternZodiac.Capricorn;
                default: throw new ArgumentOutOfRangeException("Invalid month");
            }
        }

        public ChineseZodiac GetChineseZodiac(DateTime birthday) 
        {
            int year = birthday.Year;
            return (ChineseZodiac)((year - 1900) % 12);
        }
        public int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;
            if (birthDate > today.AddYears(-age)) age--;
            return age;
        }
    }
}
