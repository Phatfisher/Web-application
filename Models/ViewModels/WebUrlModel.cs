using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Website1.Models
{
    public class WebUrlModel
    {
        [Required(ErrorMessage = "A url is required. For example www.url.com", AllowEmptyStrings = false)]
        [DisplayName("Enter a url")]
        [RegularExpression(@"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$", ErrorMessage = "Enter a Valid URL.")]
        public string Url { get; set; }
    }

}