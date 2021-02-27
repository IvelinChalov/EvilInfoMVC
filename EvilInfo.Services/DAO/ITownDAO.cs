using EvilInfo.Services.Models;

namespace EvilInfo.Services.DAO
{
	public interface ITownDAO
	{
		Towns GetTown(string name);
	}
}