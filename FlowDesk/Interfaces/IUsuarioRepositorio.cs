using FlowDesk.Models;

namespace FlowDesk.Interfaces
{
    public interface IUsuarioRepositorio
    {

        // a interface não contem código apenas a promessa do que deve ser feito

        LoginViewModel Validar(string Email, string Senha);

        void CriarConta(LoginViewModel usuario);
    }
}
