using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.Reflection.Metadata;
using tp_sveikatele.Models;

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

    public string ApplicationUserId { get; set; } // Required foreign key property
    public ApplicationUser User1 { get; set; } = null!; // Required reference navigation to principal

}
