using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace L06HandsOn.Models
{
	public class Alien
	{
		public int Id { get; set; }

		[Range(typeof(int), "0", "20")]
		public int Arms { get; set; }

		[Range(typeof(int), "0", "7")]
		public int Head
		{
			get; set;
		}
		[Range(typeof(int), "0", "1000")]
		public int Legs
		{
			get; set;
		}

		public DateTime BirthDate { get; set; }

		public enum Planets
		{
			Mercury,
			Venus,
			Earth,
			WhatOnceWas,
			Jupiter,
			Saturn,
			Neptune,
			Uranus,
			TheUnappreciatedPluto
		}

		public Planets PlanetOfOrigin { get; set; }

	}
}
