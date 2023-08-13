using System;
using EasyCash_BusinessLogicLayer.Abstract;
using EasyCash_DataAccessLayer.Abstract;
using EasyCash_EntityLayer.Concrete;

namespace EasyCash_BusinessLogicLayer.Concrete
{
	public class CustomerAccountProcessManager : ICustomerAccountProcessService
	{
        private readonly ICustomerAccountProcessDal _customerAccountProcess;

		public CustomerAccountProcessManager(ICustomerAccountProcessDal customerAccountProcess)
		{
            _customerAccountProcess = customerAccountProcess;
		}
        
        public void TDelete(CustomerAccountProcess s)
        {
            _customerAccountProcess.Delete(s);
        }

        public CustomerAccountProcess TGetByID(int ID)
        {
            return _customerAccountProcess.GetByID(ID);
        }

        public List<CustomerAccountProcess> TGetList()
        {
            return _customerAccountProcess.GetList();
        }

        public void TInsert(CustomerAccountProcess s)
        {
            _customerAccountProcess.Insert(s);
        }

        public void TUpdate(CustomerAccountProcess s)
        {
            _customerAccountProcess.Update(s);
        }
    }
}

