using MinhasTarefasAPI.Models;

namespace MinhasTarefasAPI.Repositories.Contracts
{
    interface IUsuarioRepository
    {

        void Cadastrar(ApplicationUser usuario, string senha);

        ApplicationUser Obter(string email, string senha);


    }
}
