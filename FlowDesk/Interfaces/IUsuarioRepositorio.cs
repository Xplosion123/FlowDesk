using FlowDesk.DTOs;

namespace FlowDesk.Interfaces
{
    public interface IUsuarioRepositorio
    {
        UsuarioViewModel? Validar(string email, string senha);
        void CriarConta(CriarContaDto usuario);
    }
}
