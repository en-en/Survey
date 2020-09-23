using Cyg.Applicatio.Service;
using Cyg.Applicatio.Survey.Dto;
using Cyg.Extensions.WebApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Cyg.Application.Api.Controllers
{
    /// <summary>
    /// 工程管理
    /// </summary>
    public class ProjectController : BaseApiController<IProjectService>
    {
        #region 获取工程列表
        /// <summary>
        /// 获取工程列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("GetList")]
        public Task<List<ProjectResponse>> GetListAsync(ProjectRequest request)
        {
            return Service.GetListAsync(request);
        }
        #endregion

        #region 获取工程明细
        /// <summary>
        /// 获取工程明细
        /// </summary>
        /// <param name="projectId">工程编号</param>
        /// <returns></returns>
        [HttpGet("GetDetail")]
        public Task<ProjectDetailResponse> GetDetailAsync([DisplayName("工程编号"), Required(ErrorMessage = "{0} 不能为空")]string projectId)
        {
            return Service.GetDetailAsync(projectId);
        }
        #endregion

        #region 上报勘测数据
        /// <summary>
        /// 上报勘测数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("ReportSurveyData")]
        [ApiLog]
        public async Task ReportSurveyDataAsync(ReportSurveyDataRequest request)
        {
            await Service.ReportSurveyDataAsync(request);
        }
        #endregion

        #region 完成勘察
        /// <summary>
        /// 完成勘察
        /// </summary>
        /// <param name="projectId">工程编号</param>
        /// <returns></returns>
        [HttpGet("CompleteSurvey")]
        [ApiLog]
        public Task CompleteSurveyAsync([DisplayName("工程编号"), Required(ErrorMessage = "{0} 不能为空")]string projectId)
        {
            return Service.CompleteSurveyAsync(projectId);
        }
        #endregion

        #region 上传交底数据
        /// <summary>
        /// 上传交底数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("ReportDisclosureData")]
        [ApiLog]
        public Task ReportDisclosureDataAsync(ReportDisclosureDataRequest request)
        {
            return Service.ReportDisclosureDataAsync(request);
        }
        #endregion

        #region 完成交底
        /// <summary>
        /// 完成交底
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("CompleteDisclosure")]
        [ApiLog]
        public Task CompleteDisclosureAsync(CompleteDisclosureRequest request)
        {
            return Service.CompleteDisclosureAsync(request);
        }
        #endregion

        //[HttpPost("Test")]
        //[AllowAnonymous]
        //public async Task Test(string id)
        //{
        //    await Ioc.GetService<IGisTransformService>().GisTransformProjectAsync(new List<string> { id });
        //    await Ioc.GetService<IGisTransformService>().GisTransformDisclosureTrack(new List<string>() { id });
        //}

        /// <summary>
        ///     修复数据
        /// </summary>
        /// <param name="projects"></param>
        /// <returns></returns>
        [HttpPost("RepairData")]
        public async Task RepairData(List<string> projects, bool isCoverDesign)
        {
            try
            {
                await Task.Run(()=> Service.RepairData(projects, isCoverDesign)) ;
            }
            catch (Exception e)
            {
             return;
            }
        }

        /// <summary>
        ///     修复数据
        /// </summary>
        /// <param name="projects"></param>
        /// <returns></returns>
        [HttpPost("ClearDesignData")]
        public async Task ClearDesignData()
        {
            try
            {
                await Task.Run(() => Service.ClearDesignData());
            }
            catch (Exception e)
            {
                return;
            }
        }
        
    }
}