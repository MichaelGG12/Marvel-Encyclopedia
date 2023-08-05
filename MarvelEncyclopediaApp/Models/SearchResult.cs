namespace MarvelApp.Models
{
    public class SearchResult
    {
        public Datawrapper? Data { get; set; }
        
        public class Datawrapper
        {
            public List<Result>? Results { get; set; }
        }

        public class Result
        {
            public int? Id { get; set; }
            public string? Name { get; set; }
            public string? FullName { get; set; }
            public string? Title { get; set; }
            public string? Description { get; set; }
            public Image? Thumbnail { get; set; }
            public ComicList? Comics { get; set; }

            public class Image
            {
                public string? Path { get; set; }
                public string? Extension { get; set; }
            }

            public class ComicList
            {
                public List<ComicSummary>? Items { get; set; }               
            }

            public class ComicSummary
            {
                public string? Name { get; set; }
            }
        }
    }
}
