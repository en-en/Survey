using AutoMapper.Configuration;
using Cyg.Applicatio.Entity;
using Cyg.Applicatio.Survey.Dto;
using Cyg.Extensions.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Cyg.Applicatio.Service.Impl.Internal
{
    [Dependency(ServiceLifetime.Singleton)]
    public class AutoMapperConfiguration : IAutoMapperConfiguration
    {
        public void CreateMaps(MapperConfigurationExpression mapper)
        {
            mapper.CreateMap<TowerRequest, SurveyTower>();
            mapper.CreateMap<TowerRequest, DesignTower>();
            mapper.CreateMap<CableRequest, SurveyCable>();
            mapper.CreateMap<CableRequest, DesignCable>();
            mapper.CreateMap<CableRequest, SurveyCableExt>();
            mapper.CreateMap<CableRequest, DesignCableExt>();
            mapper.CreateMap<CableEquipmentRequest, SurveyCableEquipment>();
            mapper.CreateMap<CableEquipmentRequest, DesignCableEquipment>();
            mapper.CreateMap<OverheadEquipmentRequest, SurveyOverheadEquipment>();
            mapper.CreateMap<OverheadEquipmentRequest, DesignOverheadEquipment>();
            mapper.CreateMap<LineRequest, SurveyLine>();
            mapper.CreateMap<LineRequest, DesignLine>();
            mapper.CreateMap<MarkRequest, SurveyMark>();
            mapper.CreateMap<MarkRequest, DesignMark>();
            mapper.CreateMap<ReportTrackRecord, ProjectTrackRecord>();
            mapper.CreateMap<CableChannelRequest, SurveyCableChannel>();
            mapper.CreateMap<CableChannelRequest, DesignCableChannel>();
            mapper.CreateMap<ReportDisclosure, ProjectDisclosure>();
            mapper.CreateMap<ReportDisclosureItem, ProjectDisclosureItem>();
            mapper.CreateMap<News, NewsResponse>();
            mapper.CreateMap<NewsContent, NewsResponse>();

            mapper.CreateMap<TowerRequest, DismantleTower>();
            mapper.CreateMap<CableRequest, DismantleCable>();
            mapper.CreateMap<CableRequest, DismantleCableExt>();
            mapper.CreateMap<CableChannelRequest, DismantleCableChannel>();
            mapper.CreateMap<CableEquipmentRequest, DismantleCableEquipment>();
            mapper.CreateMap<OverheadEquipmentRequest, DismantleOverheadEquipment>();
            mapper.CreateMap<LineRequest, DismantleLine>();
            mapper.CreateMap<MarkRequest, DismantleMark>();
            mapper.CreateMap<LineRequest, SurveyLineExt>();
            mapper.CreateMap<LineRequest, DesignLineExt>();
            mapper.CreateMap<LineRequest, DismantleLineExt>();

            mapper.CreateMap<MediaRequest, SurveyMedia>();
            mapper.CreateMap<MediaRequest, DesignMedia>();
            mapper.CreateMap<MediaRequest, DismantleMedia>();
        }
    }
}
