namespace Web
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PostRequestModelBody
    {
        [Required]
        [MinLength(1)]
        public IEnumerable<long> ItemIds { get; set; }
    }
}