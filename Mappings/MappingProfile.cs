using AutoMapper;
using be.Models;
using be.DTOs;

namespace be.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Account Mappings
            CreateMap<Account, AccountDto>();
            CreateMap<CreateAccountDto, Account>();
            CreateMap<UpdateAccountDto, Account>();

            // User Mappings
            CreateMap<User, UserDto>();
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();

            // Role Mappings
            CreateMap<Role, RoleDto>();
            CreateMap<CreateRoleDto, Role>();

            // Order Mappings
            CreateMap<Order, OrderDto>();
            CreateMap<CreateOrderDto, Order>();

            // Invoice Mappings
            CreateMap<Invoice, InvoiceDto>();
            CreateMap<CreateInvoiceDto, Invoice>();

            // Address Mappings
            CreateMap<Address, AddressDto>();
            CreateMap<CreateAddressDto, Address>();

            // Cart Mappings
            CreateMap<Cart, CartDto>();
            CreateMap<CreateCartDto, Cart>();

            // Product Mappings
            CreateMap<Product, ProductDto>();
            CreateMap<CreateProductDto, Product>();

            // Category Mappings
            CreateMap<Category, CategoryDto>();
            CreateMap<CreateCategoryDto, Category>();

            // Rating Mappings
            CreateMap<Rating, RatingDto>();
            CreateMap<CreateRatingDto, Rating>();

        }
    }
}
