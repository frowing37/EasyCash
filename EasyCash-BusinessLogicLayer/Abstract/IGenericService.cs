using System;
namespace EasyCash_BusinessLogicLayer.Abstract
{
	public interface IGenericService<T> where T : class
	{
		void TInsert(T s);
		void TDelete(T s);
		void TUpdate(T s);
		T TGetByID(int ID);
		List<T> TGetList();
	}
}

