using System;

namespace CodeTestApp
{
    #region Original Bad Code
    /// <summary>
    /// Reference to http://www.codeproject.com/Articles/1083348/Csharp-BAD-PRACTICES-Learn-how-to-make-a-good-code
    /// </summary>
    internal class Class1
    {
        public decimal Calculate(decimal ammount, int type, int years)
        {
            decimal result = 0;
            decimal disc = (years > 5) ? (decimal)5 / 100 : (decimal)years / 100;
            if (type == 1)
            {
                result = ammount;
            }
            else if (type == 2)
            {
                result = (ammount - (0.1m * ammount)) - disc * (ammount - (0.1m * ammount));
            }
            else if (type == 3)
            {
                result = (0.7m * ammount) - disc * (0.7m * ammount);
            }
            else if (type == 4)
            {
                result = (ammount - (0.5m * ammount)) - disc * (ammount - (0.5m * ammount));
            }
            return result;
        }
    }
    #endregion

    #region Renaming

    public class DiscountManager
    {
        public decimal AddDiscount(decimal price, int accountStatus, int timeOfHavingAccountInYears)
        {
            decimal priceAfterDiscount = 0;
            decimal discountForLoyaltyInPercentage = (timeOfHavingAccountInYears > 5) ? (decimal)5 / 100 : (decimal)timeOfHavingAccountInYears / 100;
            if (accountStatus == 1)
            {
                priceAfterDiscount = price;
            }
            else if (accountStatus == 2)
            {
                priceAfterDiscount = (price - (0.1m * price)) - (discountForLoyaltyInPercentage * (price - (0.1m * price)));
            }
            else if (accountStatus == 3)
            {
                priceAfterDiscount = (0.7m * price) - (discountForLoyaltyInPercentage * (0.7m * price));
            }
            else if (accountStatus == 4)
            {
                priceAfterDiscount = (price - (0.5m * price)) - (discountForLoyaltyInPercentage * (price - (0.5m * price)));
            }

            return priceAfterDiscount;
        }

        #region Removing Magic Numbers

        public decimal AddDiscount_(decimal price, AccountStatuses accountStatus, int timeOfHavingAccountInYears)
        {
            decimal priceAfterDiscount = 0;
            decimal discountForLoyaltyInPercentage = (timeOfHavingAccountInYears > 5) ? (decimal)5 / 100 : (decimal)timeOfHavingAccountInYears / 100;

            if (accountStatus == AccountStatuses.NotRegistered)
            {
                priceAfterDiscount = price;
            }
            else if (accountStatus == AccountStatuses.SimpleCustomer)
            {
                priceAfterDiscount = (price - (0.1m * price)) - (discountForLoyaltyInPercentage * (price - (0.1m * price)));
            }
            else if (accountStatus == AccountStatuses.ValuableCustomer)
            {
                priceAfterDiscount = (0.7m * price) - (discountForLoyaltyInPercentage * (0.7m * price));
            }
            else if (accountStatus == AccountStatuses.MostValuableCustomer)
            {
                priceAfterDiscount = (price - (0.5m * price)) - (discountForLoyaltyInPercentage * (price - (0.5m * price)));
            }
            return priceAfterDiscount;
        }

        public enum AccountStatuses
        {
            NotRegistered = 1,
            SimpleCustomer = 2,
            ValuableCustomer = 3,
            MostValuableCustomer = 4
        }

        public decimal AddDiscount(decimal price, AccountStatuses accountStatus, int timeOfHavingAccountInYears)
        {
            decimal priceAfterDiscount;
            switch (accountStatus)
            {
                case AccountStatuses.NotRegistered:
                    priceAfterDiscount = price;
                    break;
                case AccountStatuses.SimpleCustomer:
                    priceAfterDiscount = price.AddDiscountForAccountStatus(Constants.DISCOUNT_FOR_SIMPLE_CUSTOMERS);
                    break;
                case AccountStatuses.ValuableCustomer:
                    //priceAfterDiscount = (0.7m * price);
                    //Refactor the calc formula.
                    priceAfterDiscount = price.AddDiscountForAccountStatus(Constants.DISCOUNT_FOR_VALUABLE_CUSTOMERS);
                    break;
                case AccountStatuses.MostValuableCustomer:
                    priceAfterDiscount = price.AddDiscountForAccountStatus(Constants.DISCOUNT_FOR_MOST_VALUABLE_CUSTOMERS);
                    break;
                default:
                    //Not obvious
                    //Below code was modified to throw an NotImplementedException if none conditions are satisfied – the default section of switch-case statement.
                    throw new NotImplementedException();
            }
            priceAfterDiscount = priceAfterDiscount.AddDiscountForTimeOfHavingAccount(timeOfHavingAccountInYears);
            return priceAfterDiscount;
        }

        #endregion
    }


    /// <summary>
    /// All constants in the same class
    /// </summary>
    public static class Constants
    {
        public const decimal MAXIMUM_DISCOUNT_FOR_LOYALTY = 0.1m;
        public const decimal DISCOUNT_FOR_SIMPLE_CUSTOMERS = 0.1m;
        public const decimal DISCOUNT_FOR_VALUABLE_CUSTOMERS = 0.3m;
        public const decimal DISCOUNT_FOR_MOST_VALUABLE_CUSTOMERS = 0.5m;
    }

    public static class PriceExtensions
    {
        public static decimal AddDiscountForAccountStatus(this decimal price, decimal discountSize)
        {
            return price - (discountSize * price);
        }

        public static decimal AddDiscountForTimeOfHavingAccount(this decimal price, int timeOfHavingAccountInYears)
        {
            decimal discountForLoyaltyInPercentage = (timeOfHavingAccountInYears > Constants.MAXIMUM_DISCOUNT_FOR_LOYALTY) ? (decimal)Constants.MAXIMUM_DISCOUNT_FOR_LOYALTY / 100 : (decimal)timeOfHavingAccountInYears / 100;
            return price - (discountForLoyaltyInPercentage * price);
        }
    }

    #endregion

}
