using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int OrderLineId { get; set; }
        public int Rating { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }
        public IList<ReviewResponseDto> Responses { get; set; }
        public IList<ReviewImageDto> Images { get; set; }

        public ReviewDto()
        {
            Responses = new List<ReviewResponseDto>();
            Images = new List<ReviewImageDto>();
        }
    }
}
