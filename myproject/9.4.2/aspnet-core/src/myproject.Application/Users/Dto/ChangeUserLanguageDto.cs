using System.ComponentModel.DataAnnotations;

namespace myproject.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}