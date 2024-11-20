// <copyright file="MappingProfile.cs" company="Ofima S.A.S.">
// All rights reserved Ofima S.A.S.
// </copyright>

namespace Ofm.EmployeeManager.Entities.Business.Map
{
    using AutoMapper;
    using Ofm.EmployeeManager.Entities.Business.Entities.Dtos;
    using Ofm.EmployeeManager.Entities.Entities.Erp;

    /// <summary>
    /// Defines the mapping configuration for AutoMapper.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public MappingProfile()
        {
            // Map from Employee to EmployeeDto (for returning data, read-only)
            this.CreateMap<Employee, EmployeeDto>();

            // Map from EmployeeDto to Employee (used for updating or saving data)
            this.CreateMap<EmployeeDto, Employee>()
                .ForMember(dest => dest.EmployeeId, opt => opt.Ignore());

            // Map from EmployeeCreateDto to Employee (for creating a new employee)
            this.CreateMap<EmployeeDto, Employee>()
                .ForMember(dest => dest.EmployeeId, opt => opt.Ignore()) // Ignore EmployeeId as it's auto-generated
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()) // We'll hash the password manually
                .ForMember(dest => dest.PasswordSalt, opt => opt.Ignore()) // We'll generate the salt manually
                .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => DateTime.Now)) // Set CreationDate
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.Now)); // Set LastModifiedDate
        }
    }
}
