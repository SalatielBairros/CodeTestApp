using System;

namespace CodeTestApp.Pratices.BuilderFacets
{
    public static class FacetsExecute
    {
        public static void Execute()
        {
            var pb = new PersonBuilder();
            Person person = pb
                .Lives
                .At("123 London Road")
                .In("London")
                .WithPostcode("SW12BC")
                .Works
                .At("Fabrikam")
                .AsA("Engineer")
                .Earning(123000);

            Console.WriteLine(person);
        }
    }
}