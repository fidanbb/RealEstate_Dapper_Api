﻿using Dapper;
using RealEstate_Dapper_Api.Dtos.AppUserDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.AppUserRepositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly Context _context;

        public AppUserRepository(Context context)
        {
            _context = context;
        }

        public async Task<GetAppUserByProductIdDto> GetAppUserByProductIdAsync(int id)
        {
            string query = "select UserId,Name,PhoneNumber,UserImageUrl,Email from AppUser \r\ninner join Product on Product.AppUserId = AppUser.UserId \r\nwhere Product.ProductId=@productId";

            var parameters = new DynamicParameters();

            parameters.Add("@productId", id);

            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetAppUserByProductIdDto>(query,parameters);

                return value;
            }
        }
    }
}
