namespace ASOFOTEC_Web.Services
{
    public class RandomService: IRandomService
    {
        private readonly int _value;

        public int value => _value;

         public RandomService()
         {
            var random = new Random();
            _value = random.Next(2000);
         }
    }
}
