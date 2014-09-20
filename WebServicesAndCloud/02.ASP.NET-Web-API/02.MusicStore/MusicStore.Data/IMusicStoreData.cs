namespace MusicStore.Data
{
    using MusicStore.Data.Repositories;
    using MusicStore.Models;

    public interface IMusicStoreData
    {
        IGenericRepository<Album> Albums { get; }

        IGenericRepository<Song> Songs { get; }

        IGenericRepository<Artist> Artists { get; }

        void SaveChanges();
    }
}