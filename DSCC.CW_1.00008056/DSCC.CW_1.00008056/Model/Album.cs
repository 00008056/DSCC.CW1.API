using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DSCC.CW_1._00008056.Model
{
    public class Album
    {
        //An album model class that represents an album object
        public int AlbumId { get; set; }

        public string Name { get; set; }

        public int ReleaseYear { get; set; }

        public string Genre { get; set; }

        public decimal Price { get; set; }

        //A property that will retrieve the the ArtistId column (foreign key) from the DB and pass it to UI(ASP.NET Framerwork MVC)
        public int AlbumArtistId { get; set; }
        //A foreign key for connecting tables Albums and Artists
        [JsonIgnore]
        public Artist AlbumArtist { get; set; }

    }
}
