using MessagePack;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackcofferAssigment.Models
{
    public class UserData
    {
        
        public int Id { get; set; }
        public int end_year { get; set; }
        public int intensity { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string sector { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string topic { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string insight { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string url { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string regiion { get; set; }

        public int start_year { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string impact { get; set; }


        [Column(TypeName = "nvarchar(200)")]
        public string added { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string published { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string country { get; set; }

        public int relevance { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string pestle { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string source { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string title { get; set; }

        public int likelihood { get; set; }
    }
}
