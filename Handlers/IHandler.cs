using System.Threading.Tasks;
namespace AddUpdateTransaction.Handlers
{
    public interface IHandler<T> where T : class
    {
        Task Handle(T entity);
    }
}