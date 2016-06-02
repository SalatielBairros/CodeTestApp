using System;

namespace CodeTestApp.Pratices
{
    public class DiscountManager
    {
        private readonly IAccountDiscountCalculatorFactory _factory;
        private readonly ILoyaltyDiscountCalculator _loyaltyDiscountCalculator;

        public DiscountManager(IAccountDiscountCalculatorFactory factory, ILoyaltyDiscountCalculator loyaltyDiscountCalculator)
        {
            _factory = factory;
            _loyaltyDiscountCalculator = loyaltyDiscountCalculator;
        }

        public decimal AddDiscount(decimal price, CodeTestApp.DiscountManager.AccountStatuses accountStatus, int timeOfHavingAccountInYears)
        {
            decimal priceAfterDiscount = _factory.GetAccountDiscountCalculator(accountStatus).AddDiscount(price);
            priceAfterDiscount = _loyaltyDiscountCalculator.AddDiscount(priceAfterDiscount, timeOfHavingAccountInYears);
            return priceAfterDiscount;
        }
    }

    #region LoyaltyDiscountCalculator

    public interface ILoyaltyDiscountCalculator
    {
        decimal AddDiscount(decimal price, int timeOfHavingAccountInYears);
    }

    public class DefaultLoyaltyDiscountCalculator : ILoyaltyDiscountCalculator
    {
        public decimal AddDiscount(decimal price, int timeOfHavingAccountInYears)
        {
            decimal discountForLoyaltyInPercentage = (timeOfHavingAccountInYears > Constants.MAXIMUM_DISCOUNT_FOR_LOYALTY) ? 
                Constants.MAXIMUM_DISCOUNT_FOR_LOYALTY / 100 : (decimal)timeOfHavingAccountInYears / 100;
            return price - (discountForLoyaltyInPercentage * price);
        }
    }

    #endregion

    #region Factory

    public interface IAccountDiscountCalculatorFactory
    {
        IAccountDiscountCalculator GetAccountDiscountCalculator(CodeTestApp.DiscountManager.AccountStatuses accountStatus);
    }

    public class DefaultAccountDiscountCalculatorFactory : IAccountDiscountCalculatorFactory
    {
        public IAccountDiscountCalculator GetAccountDiscountCalculator(CodeTestApp.DiscountManager.AccountStatuses accountStatus)
        {
            IAccountDiscountCalculator calculator;
            switch (accountStatus)
            {
                case CodeTestApp.DiscountManager.AccountStatuses.NotRegistered:
                    calculator = new NotRegisteredDiscountCalculator();
                    break;
                case CodeTestApp.DiscountManager.AccountStatuses.SimpleCustomer:
                    calculator = new SimpleCustomerDiscountCalculator();
                    break;
                case CodeTestApp.DiscountManager.AccountStatuses.ValuableCustomer:
                    calculator = new ValuableCustomerDiscountCalculator();
                    break;
                case CodeTestApp.DiscountManager.AccountStatuses.MostValuableCustomer:
                    calculator = new MostValuableCustomerDiscountCalculator();
                    break;
                default:
                    throw new NotImplementedException();
            }

            return calculator;
        }
    }

    #endregion

    #region AccountDiscountCalculator

    public interface IAccountDiscountCalculator
    {
        decimal AddDiscount(decimal price);
    }

    public class NotRegisteredDiscountCalculator : IAccountDiscountCalculator
    {
        public decimal AddDiscount(decimal price)
        {
            return price;
        }
    }

    public class SimpleCustomerDiscountCalculator : IAccountDiscountCalculator
    {
        public decimal AddDiscount(decimal price)
        {
            return price - (Constants.DISCOUNT_FOR_SIMPLE_CUSTOMERS * price);
        }
    }

    public class ValuableCustomerDiscountCalculator : IAccountDiscountCalculator
    {
        public decimal AddDiscount(decimal price)
        {
            return price - (Constants.DISCOUNT_FOR_VALUABLE_CUSTOMERS * price);
        }
    }

    public class MostValuableCustomerDiscountCalculator : IAccountDiscountCalculator
    {
        public decimal AddDiscount(decimal price)
        {
            return price - (Constants.DISCOUNT_FOR_MOST_VALUABLE_CUSTOMERS * price);
        }
    }

    #endregion
}