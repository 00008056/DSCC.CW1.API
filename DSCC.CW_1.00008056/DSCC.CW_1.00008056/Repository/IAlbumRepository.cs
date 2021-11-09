using DSCC.CW_1._00008056.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSCC.CW_1._00008056.Repository
{
    public interface IAlbumRepository
    {
        void InsertAlbum(Album album);

        void UpdateAlbum(Album album);

        void DeleteAlbum(int albumId);

        Album GetAlbumById(int Id);

        IEnumerable<Album> GetAlbums();

    }
}
