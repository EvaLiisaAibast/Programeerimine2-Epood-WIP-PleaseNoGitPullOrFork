using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class ReviewImageDto
    {
        public int Id { get; set; }
        public int ReviewId { get; set; }
        public string ReviewTitle { get; set; }
        public string Url { get; set; }
    }
}
