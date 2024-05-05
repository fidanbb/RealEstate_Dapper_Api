namespace RealEstate_Dapper_Api.Repositories.StatisticsRepositories
{
    public interface IStatisticsRepository
    {
        Task<int> CategoryCountAsync();
        Task<int> ActiveCategoryCountAsync();
        Task<int> PassiveCategoryCountAsync();
        Task<int> ProductCountAsync();
        Task<int> ApartmentCountAsync();
        Task<string > EmployeeNameByMaxProductCountAsync();
        Task<string > CategoryNameByMaxProductCountAsync();
        Task<decimal > AverageProductPriceByRentAsync();
        Task<decimal > AverageProductPriceBySaleAsync();
        Task<string > CityNameByMaxProductCountAsync();
        Task<int > DifferentCityCountAsync();
        Task<decimal > LastProductPriceAsync();
        Task<string > NewestBuildingYearAsync();
        Task<string > OldestBuildingYearAsync();
        Task<int > AverageRoomCountAsync();
        Task<int > ActiveEmployeeCountAsync();


    }
}
