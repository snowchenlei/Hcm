﻿using System;
using Volo.Abp.Application.Dtos;

namespace Snow.Hcm.EmployeeManagement.WorkExperiences.Dtos
{
    /// <summary>
    /// 列表
    /// </summary>
    public class WorkExperienceListDto: EntityDto<System.Guid>
    {
        public string CompanyName { get; set; }
        public string Post { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public System.DateTime CreationTime { get; set; }
    }
}