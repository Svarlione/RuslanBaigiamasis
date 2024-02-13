namespace RuslanAPI.DTO_original.BookDto
{
    public class UpdateBookDto
    {
        public int Id { get; set; }
        /// <summary>
        /// CoverTypes can be only: Hardcover, Paperback, Ebook.
        /// </summary>
        public string CoverType { get; set; }
        /// <summary>
        /// Title can not be longer than 150 characters.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Author can have only regular characters, letters, numbers, sapces.
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// PublishYear can not be from the future.
        /// </summary>
        public DateTime PublishYear { get; set; }
    }
}
