using EvilInfo.Services.Models;

namespace EvilInfo.Services.DAO
{
	public interface IRoleDAO
	{
		Roles GetRole(string name);
	}
}