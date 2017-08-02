using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private double _Operand1;
        private double _Operand2;
        private double _Result = double.NaN;
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //protected void OnPropertyChanged1([CallerMemberName] string propertyName = null)
        //{
        //    var eventHandler = this.PropertyChanged;
        //    if (eventHandler != null)
        //    {
        //        eventHandler(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}

        public double Operand1
        {
            get { return _Operand1; }
            set
            {
                if (_Operand1 != value)
                {
                    _Operand1 = value;
                    OnPropertyChanged();
                    UpdateResult();
                }
            }
        }

        public double Operand2
        {
            get { return _Operand2; }
            set
            {
                if (_Operand2 != value)
                {
                    if (Math.Abs(value) < 1e-100) throw new ArgumentException("除数不应为0。", nameof(value));
                    _Operand2 = value;
                    OnPropertyChanged();
                    UpdateResult();
                }
            }
        }

        public double Result
        {
            get { return _Result; }
            set
            {
                if (_Result != value)
                {
                    _Result = value;
                    OnPropertyChanged();
                }
            }
        }

        private void UpdateResult()
        {
            Result = Operand1 / Operand2;
        }
    }
}
