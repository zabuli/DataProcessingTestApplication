﻿namespace DataProcessingApplication.Models
{
	public class IndicatorModel
	{
        public string Name { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
        public ParameterModel[] Parameters { get; set; }
    }
}