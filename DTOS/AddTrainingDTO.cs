using System.ComponentModel;

namespace tp_sveikatele.DTOS
{
    public class AddTrainingDTO
    {

        [DisplayName("Pratimas")]
        public string Pratimas { get; set; }

        [DisplayName("Svoris (kg)")]
        public double Svoris { get; set; }

        [DisplayName("Setai")]
        public int Setai { get; set; }

        [DisplayName("Pakartojimai")]
        public int Pakartojimai { get; set; }

    }

}

