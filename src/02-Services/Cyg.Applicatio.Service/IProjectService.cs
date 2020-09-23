using Cyg.Applicatio.Entity;
using Cyg.Applicatio.Survey.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cyg.Applicatio.Service
{
    public interface IProjectService : IScopeDependency
    {
        /// <summary>
        /// 获取工程列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<List<ProjectResponse>> GetListAsync(ProjectRequest request);

        /// <summary>
        /// 获取工程明细
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<ProjectDetailResponse> GetDetailAsync(string projectId);

        /// <summary>
        /// 上报勘测数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task ReportSurveyDataAsync(ReportSurveyDataRequest request);

        /// <summary>
        /// 修复数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task RepairData(List<string> proList,bool isCoverDesign);


        /// <summary>
        /// 清除设计数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task ClearDesignData();
        
        /// <summary>
        /// 完成勘察
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task CompleteSurveyAsync(string projectId);

        /// <summary>
        /// 上传交底数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task ReportDisclosureDataAsync(ReportDisclosureDataRequest request);

        /// <summary>
        /// 完成交底
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task CompleteDisclosureAsync(CompleteDisclosureRequest request);

        /// <summary>
        /// 检查勘测人员操作权限
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<(Project, ProjectState, Engineer)> CheckSurveyPermissionAsync(string projectId);
    }
}
