namespace Parcours_management.Data.Repositories.Parcours
{
    public class ParcourstNotFoundException : Exception
    {
        public ParcourstNotFoundException(int id)
            : base($"The product with the ID = {id.TryFormat} was not found") { }

    }
}
