using EvilInfo.Services.Models;

namespace EvilInfo.Services.DAO
{
	public interface ICountryDAO
	{
		Countries GetCoutry(string name);
	}
}