using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            var measureItems = new string[]
            {
            "л",
            "Барели",
            "м3",
            "Миллилитры",
            };


            cmbFirstType.DataSource = new List<string>(measureItems);
            cmbSecondType.DataSource = new List<string>(measureItems);
            cmbResultType.DataSource = new List<string>(measureItems);
        }


        private void txtFirst_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void txtSecond_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }


        private void cmbOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }
        private MeasureType GetMeasureType(ComboBox comboBox)
        {
            MeasureType measureType;
            switch (comboBox.Text)
            {
                case "л":
                    measureType = MeasureType.m;
                    break;
                case "Барели":
                    measureType = MeasureType.km;
                    break;
                case "м3":
                    measureType = MeasureType.au;
                    break;
                case "Миллилитры":
                    measureType = MeasureType.ps;
                    break;
                default:
                    measureType = MeasureType.m;
                    break;
            }
            return measureType;
        }

        private void Calculate()
        {
            try
            {
                var firstValue = double.Parse(txtFirst.Text);
                var secondValue = double.Parse(txtSecond.Text);
                double l = double.Parse(txtFirst.Text);
                double k = double.Parse(txtSecond.Text);
                // вместо трех страшных свитчей, три вызова нашей новой функции
                MeasureType firstType = GetMeasureType(cmbFirstType);
                MeasureType secondType = GetMeasureType(cmbSecondType);
                MeasureType resultType = GetMeasureType(cmbResultType);

                // тут сразу тип полученный передаем в момент создания экземпляра класса
                var firstLength = new Length(firstValue, firstType);
                var secondLength = new Length(secondValue, secondType);

                Length sumLength;

                switch (cmbOperation.Text)
                {
                    case "+":
                        sumLength = firstLength + secondLength;
                        break;
                    case "-":
                        sumLength = firstLength - secondLength;
                        break;
                    case "*":
                        sumLength = firstValue * secondLength;
                        break;
                    case "==":
                        if (l - k < 0)
                        {
                            sumLength = secondLength;
                        }
                        else
                        {
                            sumLength = firstLength;
                        }

                        break;
                    default:
                        sumLength = new Length(0, MeasureType.m);
                        break;
                }
                
                txtResult.Text = sumLength.To(resultType).Verbose();

            }
            catch (FormatException)
            {
                // если тип преобразовать не смогли
            }
        }

        private void cmbFirstType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void cmbSecondType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void cmbResultType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }
    }
}

