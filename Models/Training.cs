using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

public class Training
{
    [DisplayName("ID")]
    public int id { get; set; }

    [DisplayName("Pratimas")]
	public string Pratimas { get; set; }
	
	[DisplayName("Svoris (kg)")]
	public double Svoris { get; set; }

	[DisplayName("Setai")]
	public int Setai { get; set; }

	[DisplayName("Pakartojimai")]
	public int Pakartojimai { get; set; }


	
}
