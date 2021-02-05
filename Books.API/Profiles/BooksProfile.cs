using Mapster;

namespace Books.API.Profiles
{
    public static class BooksProfile
    {
        public static void Configure(TypeAdapterConfig config)
        {
            config.NewConfig<Entities.Book, Models.BookDto>()
                .Map(
                    dest => dest.Author,
                    src => $"{src.Author.FirstName} {src.Author.LastName}");
        }
    }
}
