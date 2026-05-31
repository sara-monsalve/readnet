using AutoMapper;
using ReadNet.API.DTOs.Request;
using ReadNet.API.DTOs.Response;
using ReadNet.Domain.Entities;

namespace ReadNet.API.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Author
        CreateMap<Author, AuthorResponseDTO>();
        CreateMap<AuthorRequestDTO, Author>();

        // Book
        CreateMap<Book, BookResponseDTO>();
        CreateMap<BookRequestDTO, Book>();

        // Category
        CreateMap<Category, CategoryResponseDTO>();
        CreateMap<CategoryRequestDTO, Category>();

        // Member
        CreateMap<Member, MemberResponseDTO>();
        CreateMap<MemberRequestDTO, Member>();

        // Loan
        CreateMap<Loan, LoanResponseDTO>();
        CreateMap<LoanRequestDTO, Loan>();

        // LoanDetail
        CreateMap<LoanDetail, LoanDetailResponseDTO>();
        CreateMap<LoanDetailRequestDTO, LoanDetail>();
    }
}