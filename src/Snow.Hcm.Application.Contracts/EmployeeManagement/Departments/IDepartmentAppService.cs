﻿using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Snow.Hcm.EmployeeManagement.Departments.Dtos;

namespace Snow.Hcm.EmployeeManagement.Departments
{
    /// <summary>
    /// 部门管理
    /// </summary>
    public interface IDepartmentAppService: IApplicationService
    {
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<DepartmentDetailDto> GetAsync(System.Guid id);

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="input">查询条件</param>
        /// <returns>结果</returns>
        Task<PagedResultDto<DepartmentListDto>> GetListAsync(GetDepartmentsInput input);

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<GetDepartmentForEditorOutput> GetEditorAsync(System.Guid id);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<DepartmentListDto> CreateAsync(DepartmentCreateDto input);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<DepartmentListDto> UpdateAsync(System.Guid id, DepartmentUpdateDto input);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task DeleteAsync(System.Guid id);
    }
}