using HOSPEDAJE.Areas.UsuarioArea.Payloads.MensajesDTO;

namespace HOSPEDAJE.Areas.UsuarioArea.Services.MicroServices.UsuarioCRUD.DeleteMS
{
    public interface IDeleteUsuaerioMS
    {
        Task<MensajeEstandarDTO> EliminarUsuario(int idUsuario);
    }
}
