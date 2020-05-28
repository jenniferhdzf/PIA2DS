using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPlantilla.Models
{
    public interface IVideo
    {
        List<Video> obtenerVideos();
        Video obtenerVideo(int idVideo);
        void insertarVideo(Video datosVideo);
        void eliminarVideo(int idVideo);
        void actualizarVideo(Video datosVideo);
    }
}