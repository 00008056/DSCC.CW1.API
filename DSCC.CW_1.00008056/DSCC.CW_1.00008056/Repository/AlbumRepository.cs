using DSCC.CW_1._00008056.DbContexts;
using DSCC.CW_1._00008056.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSCC.CW_1._00008056.Repository
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly CDAlbumContext _databaseContext;

        public AlbumRepository(CDAlbumContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void DeleteAlbum(int albumId)
        {
            var album = _databaseContext.Albums.Find(albumId);
            _databaseContext.Albums.Remove(album);
            Save();

        }

        public Album GetAlbumById(int albumId)
        {
            var album = _databaseContext.Albums.Find(albumId);
            _databaseContext.Entry(album).Reference(s => s.AlbumArtist).Load();
            return album;
        }

        public IEnumerable<Album> GetAlbums()
        {
            return _databaseContext.Albums.Include(s => s.AlbumArtist).ToList();
        }

        public void InsertAlbum(Album album)
        {
            _databaseContext.Add(album);
            Save();
        }

        public void Save()
        {
            _databaseContext.SaveChanges();
        }

        public void UpdateAlbum(Album album)
        {
            _databaseContext.Entry(album).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }
    }
}
