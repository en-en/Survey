using Cyg.Applicatio.Repository;
using Cyg.Extensions.Service;
using DotNetCore.CAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyg.Applicatio.Service.Impl
{
    /// <summary>
    /// 订阅服务
    /// </summary>
    public class SubscribeService: BaseSubscriberService, ISubscriberService
    {
    


        private readonly IGisTransformService gisTransformService;
        public SubscribeService(IGisTransformService gisTransformService)
        {
            this.gisTransformService = gisTransformService;
        }
        /// <summary>
        /// 转换marialdb勘察数据到Postgis
        /// </summary>
        /// <param name="projectIds"></param>
        /// <returns></returns>
        [CapSubscribe("GisTransformSurveyDataByProject")]
        public async Task GisTransformSurveyDataByProjectAysnc(List<string> projectIds)
        {
            if (projectIds.HasVal())
            {
                await gisTransformService.GisTransformProjectAsync(projectIds);
            }
        }
        [CapSubscribe("design.services.webGis.publish")]
        public async Task WebGisPubish(string data)
        {
            //告知客户端批注消息更新
            foreach (var item in SocketHandler.userDic)
            {
                item.Content = data;
                SocketHandler.SendMessage(item);
            }
        }
    }
}
