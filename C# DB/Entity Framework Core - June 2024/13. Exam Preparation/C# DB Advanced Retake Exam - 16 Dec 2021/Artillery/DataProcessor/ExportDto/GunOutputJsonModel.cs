﻿namespace Artillery.DataProcessor.ExportDto
{
    public class GunOutputJsonModel
    {
        public string GunType { get; set; } = null!;

        public int GunWeight { get; set; }

        public double BarrelLength { get; set; }

        public string Range { get; set; } = null!;
    }
}