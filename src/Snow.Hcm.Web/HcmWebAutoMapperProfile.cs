﻿using AutoMapper;
using Snow.Hcm.EmployeeManagement.Departments.Dtos;
using Snow.Hcm.EmployeeManagement.EducationExperiences.Dtos;
using Snow.Hcm.EmployeeManagement.EmergencyContacts.Dtos;
using Snow.Hcm.EmployeeManagement.Employees.Dtos;
using Snow.Hcm.EmployeeManagement.Positions.Dtos;
using Snow.Hcm.EmployeeManagement.WorkExperiences.Dtos;
using Snow.Hcm.Web.ViewModel.Departments;
using Snow.Hcm.Web.ViewModel.Employees;
using Snow.Hcm.Web.ViewModel.Employees.EducationExperiences;
using Snow.Hcm.Web.ViewModel.Employees.EmergencyContacts;
using Snow.Hcm.Web.ViewModel.Employees.WorkExperiences;
using Snow.Hcm.Web.ViewModel.Positions;
using Snow.Hcm.Web.ViewModel.Regions;
using Snow.RegionManagement.Admin.Regions;

namespace Snow.Hcm.Web
{
    public class HcmWebAutoMapperProfile : Profile
    {
        public HcmWebAutoMapperProfile()
        {
            #region Employee

            CreateMap<EmployeeCreateViewModel, EmployeeCreateDto>();
            CreateMap<EmployeeEditViewModel, EmployeeUpdateDto>();
            CreateMap<GetEmployeeForEditorOutput, EmployeeEditViewModel>();

            #endregion

            #region EmergencyContact

            CreateMap<EmergencyContactCreateViewModel, EmergencyContactCreateDto>();
            CreateMap<GetEmergencyContactForEditorOutput, EmergencyContactEditViewModel>();
            CreateMap<EmergencyContactEditViewModel, EmergencyContactUpdateDto>();

            #endregion

            #region WorkExperience

            CreateMap<WorkExperienceCreateViewModel, WorkExperienceCreateDto>();
            CreateMap<GetWorkExperienceForEditorOutput, WorkExperienceUpdateViewModel>()
                .ForMember(entity => entity.WorkTime,
                    opt => opt
                        .MapFrom(src =>
                            $"{src.StartTime:yyyy-MM-dd} ~ {src.EndTime:yyyy-MM-dd}"));
            CreateMap<WorkExperienceUpdateViewModel, WorkExperienceUpdateDto>();

            #endregion

            #region EducationExperience
            CreateMap<EducationExperienceCreateViewModel, EducationExperienceCreateDto>();
            CreateMap<GetEducationExperienceForEditorOutput, EducationExperienceUpdateViewModel>()
                 .ForMember(entity => entity.EducationTime,
                    opt => opt
                        .MapFrom(src =>
                            $"{src.StartTime:yyyy-MM-dd} ~ {src.EndTime:yyyy-MM-dd}"));
            CreateMap<EducationExperienceUpdateViewModel, EducationExperienceUpdateDto>();
            #endregion

            #region Department

            CreateMap<DepartmentCreateViewModel, DepartmentCreateDto>();
            CreateMap<GetDepartmentForEditorOutput, DepartmentEditViewModel>();
            CreateMap<DepartmentEditViewModel, DepartmentUpdateDto>();

            #endregion

            #region Position
            CreateMap<PositionCreateViewModel, PositionCreateDto>();
            CreateMap<GetPositionForEditorOutput, PositionEditViewModel>();
            CreateMap<PositionEditViewModel, PositionUpdateDto>();
            #endregion
        }
    }
}
