using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeTestApp.Eldorado
{
    public class Test
    {
        //public static void Main()
        //{
        //    string input = Console.ReadLine();
        //    Console.WriteLine(new Email(input).IsValid());
        //}
    }

    public interface ISpecification<TContext>
    {
        bool Validate(TContext context);
    }

    public interface IProcessor<TContext>
    {
        IProcessor<TContext> AddValidation<TSpecification>()
            where TSpecification : ISpecification<TContext>, new();
        bool GetResult();
    }

    public class Processor<TContext> : IProcessor<TContext>
    {
        private List<ISpecification<TContext>> _validations = new List<ISpecification<TContext>>();
        private readonly TContext _candidate;

        private Processor(TContext candidate)
        {
            _candidate = candidate;
        }

        public static Processor<TContext> For(TContext candidate) => new Processor<TContext>(candidate);

        public IProcessor<TContext> AddValidation<TSpecification>()
            where TSpecification : ISpecification<TContext>, new()
        {
            _validations.Add(new TSpecification());
            return this;
        }

        public bool GetResult()
        {
            foreach (var validation in _validations)
            {
                if (!validation.Validate(_candidate)) return false;
            }

            return true;
        }
    }

    public class Email
    {
        public Email(string email)
        {
            if (email != null && email.Contains("@") && email.Contains("."))
            {
                var aIndex = email.IndexOf('@');
                var dotIndex = email.IndexOf('.');

                User = email.Substring(0, aIndex);
                Company = email.Substring(aIndex + 1, (dotIndex - aIndex - 1));
                Domain = email.Substring(dotIndex + 1);
            }
        }

        public string User { get; } = string.Empty;
        public string Company { get; } = string.Empty;
        public string Domain { get; } = string.Empty;

        public int IsValid()
        {
            return
                Processor<Email>.For(this)
                    .AddValidation<HasValidSize>()
                    .AddValidation<UserStartsWithLatter>()
                    .AddValidation<UserIsAlphanumeric>()
                    .AddValidation<HasAValidDomain>()
                    .GetResult() ? 1 : 0;
        }
    }

    public class UserStartsWithLatter : ISpecification<Email>
    {
        public bool Validate(Email context) => char.IsLetter(context.User[0]);
    }

    public class HasValidSize : ISpecification<Email>
    {
        public bool Validate(Email context)
        {
            return
                context.User.Length > 0 && context.User.Length <= 10 &&
                context.Company.Length > 0 && context.Company.Length <= 10;
        }
    }

    public class HasAValidDomain : ISpecification<Email>
    {
        private readonly string[] _validDomains = { "com", "org" };

        public bool Validate(Email context) => _validDomains.Contains(context.Domain);
    }

    public class UserIsAlphanumeric : ISpecification<Email>
    {
        public bool Validate(Email context) => context.User.All(x => char.IsLetterOrDigit(x));
    }
}
