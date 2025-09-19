using webapicurso.Models;

namespace webapicurso.Services.Autor;

public interface IAutorService
{
    Task<ResponseModel<List<AutorModel>>> ListarAutores();
    Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor);
    Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro);
    Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorDto dto);
    Task<ResponseModel<List<AutorModel>>> EditarAutor(int idAutor, AutorDto dto);
    Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int idAutor);

}