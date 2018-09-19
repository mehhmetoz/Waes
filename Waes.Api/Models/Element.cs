using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Waes.Api.Models
{
    public class Element
    {
        [Key]
        public int ElementId { get; set; }
        public int Id { get; set; }
        public string Value { get; set; }
        public string Direction { get; set; }
    }
}
