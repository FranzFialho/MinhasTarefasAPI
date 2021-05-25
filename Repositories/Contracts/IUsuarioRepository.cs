using MinhasTarefasAPI.Models;

namespace MinhasTarefasAPI.Repositories.Contracts
{
    public interface IUsuarioRepository
    {

        void Cadastrar(ApplicationUser usuario, string senha);

        ApplicationUser Obter(string email, string senha);


    }
}
