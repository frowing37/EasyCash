using System;
using EasyCash_BusinessLogicLayer.Abstract;
using EasyCash_DataAccessLayer.Abstract;
using EasyCash_EntityLayer.Concrete;

namespace EasyCash_BusinessLogicLayer.Concrete
{
    public class CustomerAccountManager : ICustomerAccountService
    {
        private readonly ICustomerAccountDal _customerAccountDal;

        public CustomerAccountManager(ICustomerAccountDal customerAccountDal)
        {
            _customerAccountDal = customerAccountDal;
        }

        public void TDelete(CustomerAccount s)
        {
            _customerAccountDal.Delete(s);
        }

        public CustomerAccount TGetByID(int ID)
        {
            return _customerAccountDal.GetByID(ID);
        }

        public List<CustomerAccount> TGetList()
        {
            return _customerAccountDal.GetList();
        }

        public void TInsert(CustomerAccount s)
        {
            _customerAccountDal.Insert(s);
        }

        public void TUpdate(CustomerAccount s)
        {
            _customerAccountDal.Update(s);
        }
    }
}

