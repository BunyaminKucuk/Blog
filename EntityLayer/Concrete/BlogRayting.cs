﻿using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class BlogRayting
    {
        [Key]
        public int BlogRaytingId { get; set; }
        public int BlogId { get; set; }
        public int BlogTotalScore { get; set; }
        public int BlogRaytingCount { get; set; }
    }
}
