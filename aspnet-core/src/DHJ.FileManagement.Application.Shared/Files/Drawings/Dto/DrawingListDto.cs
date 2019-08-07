using System;
using Abp.Application.Services.Dto;
using DHJ.FileManagement.ModelBaseInfos.Sections.Dto;

namespace DHJ.FileManagement.Files.Drawings.Dto
{
    public class DrawingListDto : EntityDto
    {
        public string FileName { get; set; }

        public string FileNumber { get; set; }

        public DateTime ReceiveDate { get; set; }

        public int TotalPages { get; set; }

        public string Remark { get; set; }

        public string DrawingNumber { get; set; }

        public SectionInfoListDto Section { get; set; }

        public DateTime CreationTime { get; set; }

        public string CreatorName { get; set; }
    }
}