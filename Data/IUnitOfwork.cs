namespace Parcours_management.Data
{
    public interface IUnitOfwork
    {
        void Save();
        Task SaveAsync();
    }

    

}

