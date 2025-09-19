using webapicurso.Models;

public interface ILivroService
{
    Task<ResponseModel<List<LivroModel>>> ListarLivros();
    Task<ResponseModel<List<LivroModel>>> ListarLivrosPorIdAutor(int idAutor);
    Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro);
    Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroDto dto);
    Task<ResponseModel<List<LivroModel>>> EditarLivro(int idLivro, LivroDto dto);
    Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int idLivro);
}