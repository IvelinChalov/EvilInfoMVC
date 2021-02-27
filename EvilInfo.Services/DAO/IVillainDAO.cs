using EvilInfo.Services.Models;

namespace EvilInfo.Services.DAO
{
	public interface IVillainDAO
	{
		EvilnessFactors GetEvilnessFactor(string name);
		VillainUsers GetVillainById(int id);
	}
}