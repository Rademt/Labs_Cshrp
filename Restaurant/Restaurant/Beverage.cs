using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Beverage : MenuItem
    {
        public int VolumeMl { get; private set; }
        public bool IsAlcoholic { get; private set; }

        public Beverage(string name, decimal price, int volumeMl, bool isAlcoholic)
            : base(name, price)
        {
            VolumeMl = volumeMl;
            IsAlcoholic = isAlcoholic;
            Category = "Напій";
        }

        public override string GetDetails()
        {
            string alcoholStatus = IsAlcoholic ? "Алкогольний" : "Безалкогольний";
            return $"Напій: {Name}, Об'єм: {VolumeMl} мл, {alcoholStatus}, Ціна: {Price:C}";
        }

        public override string ToString()
        {
            string alcohol = IsAlcoholic ? ", Алк." : ", Б/А";
            return $"{Name} ({VolumeMl} мл{alcohol}) - {Price:C}";
        }
    }
}
