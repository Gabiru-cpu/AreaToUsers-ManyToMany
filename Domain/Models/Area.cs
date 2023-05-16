using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AreaApi.Domain.Models
{
    public class Area
    {

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public DateTime Data { get; set; }

        public string OwnerUserId { get; set;}
        [ForeignKey("OwnerUserId")]
        public ApplicationUser OwnerUser { get; set; }
        // um list de usuarios do grupo 
        public List<ApplicationUser> Users { get; set; }

    }
}
