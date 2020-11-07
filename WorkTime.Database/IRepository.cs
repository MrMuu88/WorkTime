using System.Threading.Tasks;

namespace WorkTime.Database
{
	public interface IRepository<T>
	{
		Task Create(T obj);
		Task<T> Get(int id);
		Task<T> Update(T obj);
		Task Delete(int id);
	}
}
