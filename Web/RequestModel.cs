namespace Web
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc;

    public class RequestModel
    {
        public string Key { get; set; }

        [FromBody]
        [Required]
        public PostRequestModelBody Body { get; set; }
    }
}