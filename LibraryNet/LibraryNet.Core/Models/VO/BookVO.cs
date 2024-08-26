﻿using LibraryNet.Core.Enums;

namespace LibraryNet.Core.Models.VO
{
    public class BookVO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Edition { get; set; }
        public string Author { get; set; }
        public string ReleaseYear { get; set; }
        public decimal Price { get; set; }
        public LiteraryGenre Category { get; set; }
        public string Publisher { get; set; }
        public int NumberPages { get; set; }
        public string Review { get; set; }
        public string Description { get; set; }
        public List<Language> Translations { get; set; }
    }
}
