using RuslanAPI.DataLayer.Models;
using RuslanAPI.Dtos.BookDto;
using System.Text.RegularExpressions;

namespace RuslanAPI.Services
{


    public interface IValidatorBookService
    {
        bool IsValid(CreateBookDto dto);
        bool IsValid(UpdateBookDto dto);
    }
    public class ValidatorBookService : IValidatorBookService
    {
        private readonly string[] coverTypes = new string[] { "Hardcover", "Paperback", "Ebook" };
        private readonly Regex regularCharacters = new Regex(@"^[a-zA-Z0-9 ]+$");
        public bool IsValid(CreateBookDto dto)
        {
            if(!coverTypes.Contains(dto.CoverType))
            {
                return false;
            }
            if(dto.Title.Length >= 150) 
            {
                return false;
            }
            if(!regularCharacters.IsMatch(dto.Author))
            {
                return false;
            }
            if (dto.PublishYear !=null && ((DateTime)dto.PublishYear).Year > DateTime.Now.Year)
            {
                return false;
            }
            return true;
        }
        public bool IsValid(UpdateBookDto dto)
        {
            if (!coverTypes.Contains(dto.CoverType))
            {
                return false;
            }
            if (dto.Title.Length >= 150)
            {
                return false;
            }
            if (!regularCharacters.IsMatch(dto.Author))
            {
                return false;
            }
            if (dto.PublishYear != null && ((DateTime)dto.PublishYear).Year > DateTime.Now.Year)
            {
                return false;
            }
            return true;
        }
    }
}
