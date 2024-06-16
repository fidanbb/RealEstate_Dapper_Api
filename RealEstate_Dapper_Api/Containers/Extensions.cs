﻿using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Repositories.AmenityRepositories;
using RealEstate_Dapper_Api.Repositories.AppUserRepositories;
using RealEstate_Dapper_Api.Repositories.BottomGridRepositories;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;
using RealEstate_Dapper_Api.Repositories.ContactRepositories;
using RealEstate_Dapper_Api.Repositories.EmployeeRepositories;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticsRepositories;
using RealEstate_Dapper_Api.Repositories.MessageRepositories;
using RealEstate_Dapper_Api.Repositories.PopularLocationRepositories;
using RealEstate_Dapper_Api.Repositories.ProductImageRepositories;
using RealEstate_Dapper_Api.Repositories.ProductRepository;
using RealEstate_Dapper_Api.Repositories.ServiceRepository;
using RealEstate_Dapper_Api.Repositories.StatisticsRepositories;
using RealEstate_Dapper_Api.Repositories.SubFeatureRepositories;
using RealEstate_Dapper_Api.Repositories.TestimonialRepositories;
using RealEstate_Dapper_Api.Repositories.ToDoListRepositories;
using RealEstate_Dapper_Api.Repositories.WhoWeAreRepository;

namespace RealEstate_Dapper_Api.Containers
{
	public static class Extensions
	{
		public static void ContainerDependencies(this IServiceCollection services)
		{
			services.AddTransient<Context>();
			services.AddTransient<ICatogoryRepository, CategoryRepository>();
			services.AddTransient<IProductRepository, ProductRepository>();
			services.AddTransient<IWhoWeAreDetailRepository, WhoWeAreDetailRepository>();
			services.AddTransient<IServiceRepository, ServiceRepository>();
			services.AddTransient<IBottomGridRepository, BottomGridRepository>();
			services.AddTransient<IPopularLocationRepository, PopularLocationRepository>();
			services.AddTransient<ITestimonialRepository, TestimonialRepository>();
			services.AddTransient<IEmployeeRepository, EmployeeRepository>();
			services.AddTransient<RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticsRepositories.IStatisticRepository, RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticsRepositories.StatisticRepository>();
			services.AddTransient<IContactRepository, ContactRepository>();
			services.AddTransient<IToDoListRepository, ToDoListRepository>();
			services.AddTransient<IChartRepository, ChartRepository>();

			services.AddTransient<RealEstate_Dapper_Api.Repositories.StatisticsRepositories.IStatisticsRepository, RealEstate_Dapper_Api.Repositories.StatisticsRepositories.StatisticsRepository>();
			services.AddTransient<IMessageRepository, MessageRepository>();
			services.AddTransient<IProductImageRepository, ProductImageRepository>();
			services.AddTransient<IAppUserRepository, AppUserRepository>();
			services.AddTransient<IPropertyAmenityRepository, PropertyAmenityRepository>();
			services.AddTransient<ISubFeatureRepository, SubFeatureRepository>();
		}
	}
}
