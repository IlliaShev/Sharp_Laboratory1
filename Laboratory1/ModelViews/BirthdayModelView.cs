using KMA.CSharp2024.Laboratory1.Models;
using KMA.CSharp2024.Laboratory1.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KMA.CSharp2024.Laboratory1.ModelViews
{
    internal class BirthdayModelView: INotifyPropertyChanged
    {
        private Birthday _birthday = new Birthday();

        public event PropertyChangedEventHandler? PropertyChanged;
        private RelayCommand<object> _closeCommand;

        public DateTime? BirthdayDate
        {
            get
            {
                return _birthday.BirthdayDate;
            }
            set
            {
                _birthday.BirthdayDate = value;
                ValidateOnBirthdayChange();
            }
        }

        public string Age
        {
            get 
            {
                if (IsValidAge())
                {
                    return _birthday.Age.ToString();
                }
                return "";
            }
        }

        public string ChineseZod
        {
            get 
            {
                if (IsValidAge())
                {
                    return _birthday.ChineseZod.ToString();
                }
                return "";
            }
        }

        public string WesternZod
        {
            get
            {
                if (IsValidAge())
                {
                    return _birthday.WesternZod.ToString();
                }
                return "";
            }
        }

        public RelayCommand<object> CloseCommand
        {
            get
            {
                return _closeCommand ??= new RelayCommand<object>(_ => Environment.Exit(0));
            }
        }

        private bool IsValidAge()
        {
            return _birthday.Age >= 0 && _birthday.Age <= 135;
        }

        private bool IsBirthday()
        {
            if (_birthday.BirthdayDate == null)
            {
                return false;
            }
            var today = DateTime.Today;
            var birth = (DateTime)_birthday.BirthdayDate;
            return birth.Day == today.Day && birth.Month == today.Month;
        }

        private void ValidateOnBirthdayChange()
        {
            if (!IsValidAge())
            {
                MessageBox.Show("Ви ще не народились або вже занадто старі");
                _birthday.BirthdayDate = null;
            }
            if (IsBirthday())
            {
                MessageBox.Show("Вітаємо вас з днем народження!");
            }
            OnPropertyChanged(nameof(Age));
            OnPropertyChanged(nameof(WesternZod));
            OnPropertyChanged(nameof(ChineseZod));
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
