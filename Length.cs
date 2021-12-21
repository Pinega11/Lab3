using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp8
{
    public enum MeasureType { m, km, au, ps };
    public class Length
    {
        private double value;
        private MeasureType type;

        public Length(double value, MeasureType type)
        {
            this.value = value;
            this.type = type;
        }


        public string Verbose()
        {
            string typeVerbose = "";
            switch (this.type)
            {
                case MeasureType.m:
                    typeVerbose = "л.";
                    break;
                case MeasureType.km:
                    typeVerbose = "барлей.";
                    break;
                case MeasureType.au:
                    typeVerbose = "м3";
                    break;
                case MeasureType.ps:
                    typeVerbose = "миллилитры";
                    break;
            }
            return String.Format("{0} {1}", this.value, typeVerbose);
        }
        public static Length operator +(Length instance, double number)
        {

            var newValue = instance.value + number;

            var length = new Length(newValue, instance.type);

            return length;
        }


        public static Length operator +(double number, Length instance)
        {

            return instance + number;
        }

        public static Length operator *(Length instance, double number)
        {

            return new Length(instance.value * number, instance.type); ;
        }

        public static Length operator *(double number, Length instance)
        {
            return instance * number;
        }


        public static Length operator -(Length instance, double number)
        {
            return new Length(instance.value - number, instance.type); ;
        }

        public static Length operator -(double number, Length instance)
        {
            return instance - number;
        }


        public static Length operator /(Length instance, double number)
        {
            return new Length(instance.value / number, instance.type); ;
        }

        public static Length operator /(double number, Length instance)
        {
            return instance / number;
        }


        public Length To(MeasureType newType)
        {

            var newValue = this.value;

            if (this.type == MeasureType.m)
            {

                switch (newType)
                {

                    case MeasureType.m:
                        newValue = this.value;
                        break;

                    case MeasureType.km:
                        newValue = this.value / 158;
                        break;

                    case MeasureType.au:
                        newValue = this.value / 1000;
                        break;

                    case MeasureType.ps:
                        newValue = this.value * 1000;
                        break;
                }
            }
            else if (newType == MeasureType.m)
            {
                switch (this.type)
                {
                    case MeasureType.m:
                        newValue = this.value;
                        break;
                    case MeasureType.km:
                        newValue = this.value * 158;
                        break;
                    case MeasureType.au:
                        newValue = this.value * 1000;
                        break;
                    case MeasureType.ps:
                        newValue = this.value / 1000;
                        break;
                }
            }
            else
            {
                newValue = this.To(MeasureType.m).To(newType).value;

            }
            return new Length(newValue, newType);
        }
        public static Length operator +(Length instance1, Length instance2)
        {

            return instance1 + instance2.To(instance1.type).value;
        }


        public static Length operator -(Length instance1, Length instance2)
        {

            return instance1 - instance2.To(instance1.type).value;
        }
    }
}

